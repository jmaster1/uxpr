#nullable enable
using System;

namespace Xpr.xpr.Val
{

    /**
     * function with 0 arguments
     */
    internal class XprValFunc0 : XprValFunc
    {
        private Func<float>? _func;

        public XprValFunc0(string name) : base(name)
        {
        }

        public override float Eval(XprContext ctx)
        {
            _func ??= ctx.ResolveFunc0(Name);
            var result = _func.Invoke();
            return result;
        }

        public override string ToString()
        {
            return $"{Name}()";
        }
    }
}
