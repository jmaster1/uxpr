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

        public bool disabled;
        
        private Xpr.xpr.Xpr _xpr;

        public void Apply(XprContext ctx, GameObject gameObject)
        {
            if(disabled) return;
            _xpr ??= new Xpr.xpr.Xpr(src).Parse();
            var setter = property.GetSetter();
            var val = _xpr.Eval(ctx);
            setter.Invoke(gameObject, val);
        }

        public void Prepare(XprContext ctx, GameObject gameObject)
        {
            _xpr = new Xpr.xpr.Xpr(src);
            _xpr.Eval(ctx);
        }
    }
    
    public static class UXprPropertyEx
    {
        public static void Prepare(this IEnumerable<UXprProperty> properties, XprContext ctx, GameObject gameObject)
        {
            foreach (var property in properties)
            {
                property.Prepare(ctx, gameObject);
            }
        }
        
        public static void Apply(this IEnumerable<UXprProperty> properties, XprContext ctx, GameObject gameObject)
        {
            foreach (var property in properties)
            {
                property.Apply(ctx, gameObject);
            }
        }
    }
}
