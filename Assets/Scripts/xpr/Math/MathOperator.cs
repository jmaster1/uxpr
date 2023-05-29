using System;

namespace Xpr.xpr.Math
{

    public enum MathOperator
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Modulus,
        Power
    }

    public static class MathOperatorEx
    {
        public static readonly char[] Chars = {'?', '+', '-', '*', '/', '%', '^'};

        public static readonly int[] Priorities = {0, 0, 1, 1, 1, 2};

        public static char GetChar(this MathOperator val)
        {
            return Chars[(int) val];
        }

        public static int GetPriority(this MathOperator val)
        {
            return Priorities[(int) val];
        }

        public static float Apply(this MathOperator val, float l, float r)
        {
            return val switch
            {
                MathOperator.Plus => l + r,
                MathOperator.Minus => l - r,
                MathOperator.Multiply => l * r,
                MathOperator.Divide => l / r,
                MathOperator.Modulus => l % r,
                MathOperator.Power => (float)System.Math.Pow(l, r),
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }

        public static bool Resolve(char next, out MathOperator op)
        {
            var index = Array.IndexOf(Chars, next);
            op = default;
            if (index != -1)
            {
                op = (MathOperator) index;
            }
            return index != -1;
        }
    }

}