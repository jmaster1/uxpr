using System;
using UnityEngine;

namespace Xpr.xpr.Unity
{

    public class XprGOProperty : MonoBehaviour
    {
        public GOProperty Property;

        public string Source;
        
        public Xpr Xpr;
        
        public XprContext ctx => UnityXprContext.Context;

        public Uxpr[] Expressions;

        private void Awake()
        {
            Xpr = new Xpr(Source);
        }

        private void Update()
        {
            var setter = Property.GetSetter();
            var val = Xpr.Eval(ctx);
            setter.Invoke(gameObject, val);
        }
    }

}