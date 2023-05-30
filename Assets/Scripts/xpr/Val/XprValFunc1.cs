#nullable enable
using System;
using Xpr.xpr.Math;

namespace Xpr.xpr.Val
{

    /**
     * function with 1 argument
     */
    internal class XprValFunc1 : XprValFunc
    {
        public XprVal? Arg;

        private Func<float, float>? _func;

        public XprValFunc1(string name) : base(name)
        {
        }

        public XprValFunc1(MathFunc1 mf1) : base(mf1.ToString())
        {
            _func = mf1.GetFunc();
        }

        public override float Eval(XprContext ctx)
        {
            var argVal = Arg!.Eval(ctx);
            _func ??= ctx.ResolveFunc1(Name);
            var result = _func.Invoke(argVal);
            return result;
        }

        public override string ToString()
        {
            return $"{Name}({Arg})";
        }
    }
}