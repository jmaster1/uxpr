using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprProperties : MonoBehaviour
    {
        private static XprContext Ctx => UXprContext.Context;

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
                property.Apply(Ctx, gameObject);
            }
        }
    }

}