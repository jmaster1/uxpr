using System;
using UnityEngine;

namespace xpr.Math
{

    /**
 * math functions with 2 arguments
 */
    public enum MathFunc2
    {
        Add,
        Sub,
        Mul,
        Div,
        Mod,
        Pow,
        Min,
        Max
    }

    public static class MathFunc2Ex
    {
        public static Func<float, float, float> GetFunc(this MathFunc2 val)
        {
            return val switch
            {
                MathFunc2.Add => (arg1, arg2) => arg1 + arg2,
                MathFunc2.Sub => (arg1, arg2) => arg1 - arg2,
                MathFunc2.Mul => (arg1, arg2) => arg1 * arg2,
                MathFunc2.Div => (arg1, arg2) => arg1 / arg2,
                MathFunc2.Mod => (arg1, arg2) => arg1 % arg2,
                MathFunc2.Pow => Mathf.Pow,
                MathFunc2.Min => Mathf.Min,
                MathFunc2.Max => Mathf.Max,
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }

}
