using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprProperties : MonoBehaviour
    {
        private static XprContext Ctx => UXprContext.Context;

        public UXprProperty[] properties;
        
        private void Update()
        {
            properties.Apply(Ctx, gameObject);
        }
    }
}