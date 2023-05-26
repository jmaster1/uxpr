using System;
using UnityEngine;

namespace Xpr.xpr.Math
{

    /**
    * unity functions with no arguments
    */
    public enum UnityFunc0
    {
        T
    }

    public static class UnityFunc0Ex
    {
        public static Func<float> GetFunc(this UnityFunc0 val)
        {
            return val switch
            {
                UnityFunc0.T => () => Time.time,
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }

}
