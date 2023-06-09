#nullable enable
using xpr;
using xpr.Val;

namespace Xpr.xpr
{

    public class Xpr
    {
        public readonly string Src;

        public XprVal? Val;

        public Xpr(string src)
        {
            Src = src;
        }

        public Xpr Parse()
        {
            Val = XprParser.CreateVal(Src);
            return this;
        }

        public float Eval(XprContext ctx)
        {
            if (Val == null)
            {
                Parse();
            }

            return Val!.Eval(ctx);
        }

        public float Eval()
        {
            return Eval(XprContext.DefaultContext);
        }

        public override string? ToString()
        {
            return Val?.ToString();
        }
    }
}
