using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprContext : MonoBehaviour
    {
        public static readonly XprContext Context = XprContext.CreateDefault();

        private void Awake()
        {
            Context.Funcs0[UnityFunc0.T.ToString().ToLower()] = UnityFunc0.T.GetFunc();
        }

        private void Update()
        {
        }
    }

}