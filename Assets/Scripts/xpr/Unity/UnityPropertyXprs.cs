using UnityEngine;
using xpr.Unity;

namespace Xpr.xpr.Unity
{

    public class UnityPropertyXprs : MonoBehaviour
    {
        public static XprContext ctx => UnityXprContext.Context;
        
        [System.Serializable]
        public class UnityPropertyXpr
        {
            public UnityProperty property;
            public string src;
            private Xpr xpr;

            public void Parse()
            {
                xpr = new Xpr(src).Parse();
            }

            public void Apply(GameObject gameObject)
            {
                var setter = property.GetSetter();
                var val = xpr.Eval(ctx);
                setter.Invoke(gameObject, val);
            }
        }
        
        public UnityPropertyXpr[] properties;

        private void Awake()
        {
            foreach (var property in properties)
            {
                property.Parse();
            }
        }

        private void Update()
        {
            foreach (var property in properties)
            {
                property.Apply(gameObject);
            }
            /*
            var setter = Property.GetSetter();
            var val = Xpr.Eval(ctx);
            setter.Invoke(gameObject, val);
            */
        }
    }

}