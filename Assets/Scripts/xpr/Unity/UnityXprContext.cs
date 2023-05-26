using System;
using UnityEngine;
using xpr.Unity;
using Xpr.xpr.Math;

namespace Xpr.xpr.Unity
{

    public class UnityXprContext : MonoBehaviour
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