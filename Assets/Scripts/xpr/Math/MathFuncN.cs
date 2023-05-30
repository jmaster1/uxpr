using System;
using System.Linq;

namespace xpr.Math
{

    /**
 * math functions with arbitrary arguments
 */
    public enum MathFuncN
    {
        Sum,
        Avg
    }

    public static class MathFuncNEx
    {
        public static Func<float[], float> GetFunc(this MathFuncN val)
        {
            return val switch
            {
                MathFuncN.Sum => arg => arg.Sum(),
                MathFuncN.Avg => arg => arg.Average(),
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }

}
