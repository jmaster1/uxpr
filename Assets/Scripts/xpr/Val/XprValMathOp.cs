#nullable enable
using Xpr.xpr.Math;

namespace Xpr.xpr.Val
{

    internal class XprValMathOp : XprVal
    {
        public XprVal? Left, Right;

        public readonly MathOperator MathOperator;

        public XprValMathOp(MathOperator op, XprVal left)
        {
            MathOperator = op;
            Left = left;
        }

        public override XprValType GetValType()
        {
            return XprValType.MathOp;
        }

        public override float Eval(XprContext ctx)
        {
            var l = Left!.Eval(ctx);
            var r = Right!.Eval(ctx);
            return MathOperator.Apply(l, r);
        }

        public override string ToString()
        {
            return $"{Left} {MathOperator.GetChar()} {Right}";
        }
    }

}