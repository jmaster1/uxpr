using System;
using UnityEngine;

namespace Xpr.xpr.Unity
{

    public class Uxpr
    {
        public GOProperty Property;

        public string Source;
        
        public Xpr Xpr;
        
        public XprContext ctx => UnityXprContext.Context;
    }

}