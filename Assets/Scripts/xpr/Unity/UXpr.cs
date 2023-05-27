using Xpr.xpr;

namespace xpr.Unity
{

    [System.Serializable]
    public class UXpr
    {
        public string source;

        public Xpr.xpr.Xpr Xpr;
        
        public float Eval(XprContext ctx)
        {
            Xpr ??= new Xpr.xpr.Xpr(source);
            return Xpr.Eval(ctx);
        }
    }

}