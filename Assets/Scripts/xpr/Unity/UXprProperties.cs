using UnityEngine;
using Xpr.xpr;
using Xpr.xpr.Unity;

namespace xpr.Unity
{

    public partial class UXprProperties : MonoBehaviour
    {
        public static XprContext ctx => UXprContext.Context;

        public UXprProperty[] properties;

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
                property.Apply(ctx, gameObject);
            }
        }
    }

}