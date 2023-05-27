using System.Collections.Generic;
using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{
    [System.Serializable]
    public class UXprProperty
    {
        public UnityProperty property;
        
        public string src;
        
        private Xpr.xpr.Xpr _xpr;

        public void Apply(XprContext ctx, GameObject gameObject)
        {
            _xpr ??= new Xpr.xpr.Xpr(src).Parse();
            var setter = property.GetSetter();
            var val = _xpr.Eval(ctx);
            setter.Invoke(gameObject, val);
        }
    }
    
    public static class UXprPropertyEx
    {
        public static void Apply(this IEnumerable<UXprProperty> properties, XprContext ctx, GameObject gameObject)
        {
            foreach (var property in properties)
            {
                property.Apply(ctx, gameObject);
            }
        }
    }
}
