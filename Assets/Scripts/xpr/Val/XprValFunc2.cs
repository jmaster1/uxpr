#nullable enable
using System;

namespace xpr.Val
{

    /**
     * function with 2 arguments
     */
    internal class XprValFunc2 : XprValFunc
    {
        public XprVal? Arg1;

        public XprVal? Arg2;

        private Func<float, float, float>? _func;

        public XprValFunc2(string name) : base(name)
        {
        }

        public override float Eval(XprContext ctx)
        {
            var arg1Val = Arg1!.Eval(ctx);
            var arg2Val = Arg2!.Eval(ctx);
            _func ??= ctx.ResolveFunc2(Name);
            var result = _func.Invoke(arg1Val, arg2Val);
            return result;
        }

        public override string ToString()
        {
            return $"{Name}({Arg1}, {Arg2})";
        }
    }

}