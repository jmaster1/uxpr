using System.Globalization;
using xpr;
using xpr.Val;

namespace Xpr.xpr.Val
{

    internal class XprValNumber : XprVal
    {
        private readonly float _value;

        public XprValNumber(float value)
        {
            _value = value;
        }

        public override XprValType GetValType()
        {
            return XprValType.Number;
        }

        public override float Eval(XprContext ctx)
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }
    }

}