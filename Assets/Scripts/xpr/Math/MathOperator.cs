using System;

namespace xpr.Math
{

    public enum MathOperator
    {
        Undefined,
        Plus,
        Minus,
        Multiply,
        Divide,
        Modulus,
        Power
    }

    public static class MathOperatorEx
    {
        private static readonly char[] Chars = {'?', '+', '-', '*', '/', '%', '^'};

        private static readonly int[] Priorities = {0, 0, 1, 1, 1, 2};

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
                MathOperator.Undefined => float.NaN,
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }

        public static bool Resolve(char next, out MathOperator op)
        {
            var index = Array.IndexOf(Chars, next);
            if (index != -1)
            {
                op = (MathOperator) index;
            }
            else
            {
                op = MathOperator.Undefined;
            }

            return index != -1;
        }
    }
}