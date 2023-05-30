using System;
using System.Collections.Generic;
using System.Linq;

namespace Xpr.xpr.Math
{

    public enum MathFunc
    {
        Undefined,
        Add,
        Sub,
        Mul,
        Div,
        Mod,
        Pow
    }

    public static class MathFuncEx
    {
        public static float Add(ICollection<float> list)
        {
            return list.Sum();
        }

        public static float Sub(ICollection<float> list)
        {
            float ret = 0;
            var first = true;
            foreach (var f in list)
            {
                if (first)
                {
                    ret = f;
                    first = false;
                }
                else
                {
                    ret -= f;
                }
            }

            return ret;
        }

        public static float Mul(ICollection<float> list)
        {
            return list.Aggregate<float, float>(1, (current, f) => current * f);
        }

        public static float Div(ICollection<float> list)
        {
            float ret = 0;
            var first = true;
            foreach (var f in list)
            {
                if (first)
                {
                    ret = f;
                    first = false;
                }
                else
                {
                    ret /= f;
                }
            }

            return ret;
        }

        public static Func<ICollection<float>, float> GetFunc(this MathFunc val)
        {
            switch (val)
            {
                case MathFunc.Add:
                    return Add;
                case MathFunc.Sub:
                    return Sub;
                case MathFunc.Mul:
                    return Mul;
                case MathFunc.Div:
                    return Div;
                case MathFunc.Mod:
                case MathFunc.Pow:
                default:
                    throw new ArgumentOutOfRangeException(nameof(val), val, null);
            }
        }
    }

}
