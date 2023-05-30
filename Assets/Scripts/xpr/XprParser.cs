#nullable enable
using System;
using System.Diagnostics;
using xpr;
using xpr.Math;
using xpr.Token;
using xpr.Util;
using xpr.Val;
using Xpr.xpr.Token;
using Xpr.xpr.Val;

namespace Xpr.xpr
{

    public class XprParser : GenericEntity
    {
        private static readonly XprParser Instance = new();

        public static XprVal? CreateVal(string src)
        {
            return Instance.ParseVal(src);
        }

        private XprVal? ParseVal(string source)
        {
            var xt = new XprTokenizer(source);
            XprVal? val = null;
            while (xt.GetHasMoreTokens())
            {
                val = ParseNext(xt, val, out _);
            }

            return val;
        }

        private XprVal? ParseNext(XprTokenizer xt, XprVal? prevVal, out XprToken? unconsumedToken)
        {
            unconsumedToken = null;
            var token = xt.NextToken();
            Log($"nextToken={token}");
            if (token == null)
            {
                return null;
            }

            XprVal? val = null;
            switch (token.Type)
            {
                case XprTokenType.Number:
                    val = new XprValNumber(token.NumberValue);
                    break;
                case XprTokenType.Variable:
                    var name = token.StringValue;
                    Debug.Assert(name != null, nameof(name) + " != null");
                    var func = new XprValFuncN(name);
                    var nextToken = xt.PeekToken();
                    var opened = XprTokenType.BracketOpen.Is(nextToken);
                    if (opened)
                    {
                        Debug.Assert(nextToken != null, nameof(nextToken) + " != null");
                        xt.ConsumePeekToken(nextToken);
                        XprVal? arg = null;
                        while (opened && xt.GetHasMoreTokens())
                        {
                            var next = ParseNext(xt, arg, out token);
                            if (token != null)
                            {
                                switch (token.Type)
                                {
                                    case XprTokenType.BracketClose:
                                        if (arg != null)
                                        {
                                            func.AddArg(arg);
                                        }

                                        opened = false;
                                        break;
                                    case XprTokenType.ArgSeparator:
                                        func.AddArg(arg);
                                        arg = null;
                                        break;
                                    default:
                                        throw new XprParseException($"Unexpected child token {token} for {func}");
                                }
                            }
                            else
                            {
                                Assert(next != null);
                                arg = next;
                            }
                        }
                    }

                    if (opened)
                    {
                        throw new XprParseException($"Function {func} left unclosed");
                    }

                    val = func.Reduce();
                    break;
                case XprTokenType.BracketOpen:
                    Assert(false);
                    break;
                case XprTokenType.Operator:
                    //
                    // this might be unary minus if no prevVal
                    var op = token.MathOperator;
                    if (op == MathOperator.Minus && prevVal == null)
                    {
                        var negate = new XprValFunc1(MathFunc1.Negate);
                        var arg = ParseNext(xt, null, out token);
                        negate.Arg = RequireVal(arg);
                        val = negate;
                    }
                    else
                    {
                        var mathOp = new XprValMathOp(token.MathOperator, prevVal!);
                        //
                        // check if prev is math op with lower priority
                        var prevMathOp = prevVal!.Is(XprValType.MathOp) ? (XprValMathOp) prevVal : null;
                        if (prevMathOp != null &&
                            prevMathOp.MathOperator.GetPriority() < token.MathOperator.GetPriority())
                        {
                            mathOp.Left = prevMathOp.Right;
                            prevMathOp.Right = mathOp;
                        }
                        else
                        {
                            prevMathOp = null;
                        }

                        mathOp.Right = ParseNext(xt, mathOp, out token);
                        Assert(token == null);
                        val = prevMathOp ?? mathOp;
                    }

                    break;
                case XprTokenType.BracketClose:
                case XprTokenType.ArgSeparator:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Log($"created val={val}");
            if (val == null)
            {
                unconsumedToken = token;
            }

            return val;
        }

        private static XprVal RequireVal(XprVal? val)
        {
            if (val == null)
            {
                throw new XprParseException($"Unexpected end of stream");
            }

            return val;
        }
    }
}
