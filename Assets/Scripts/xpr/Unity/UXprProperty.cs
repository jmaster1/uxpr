using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{
    [System.Serializable]
    public class UXprProperty
    {
        public UnityProperty property;
        
        public string src;
        
        private Xpr.xpr.Xpr xpr;

        public void Parse()
        {
            xpr = new Xpr.xpr.Xpr(src).Parse();
        }

        public void Apply(XprContext ctx, GameObject gameObject)
        {
            var setter = property.GetSetter();
            var val = xpr.Eval(ctx);
            setter.Invoke(gameObject, val);
        }
    }
}
