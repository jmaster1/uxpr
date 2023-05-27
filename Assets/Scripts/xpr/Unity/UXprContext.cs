using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprContext : MonoBehaviour
    {
        public static readonly XprContext Context = Create();

        private void Awake()
        {
            Context.Funcs0[UnityFunc0.T.ToString().ToLower()] = UnityFunc0.T.GetFunc();
        }

        public static XprContext Create()
        {
            var ctx = XprContext.CreateDefault();
            ctx.Funcs0[UnityFunc0.T.ToString().ToLower()] = UnityFunc0.T.GetFunc();
            return ctx;
        }
    }

}