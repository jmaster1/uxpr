namespace xpr.Val
{

    internal class XprValDelegate : XprVal
    {
        private readonly XprVal _value;

        public XprValDelegate(XprVal value)
        {
            _value = value;
        }

        public override XprValType GetValType()
        {
            return XprValType.Delegate;
        }

        public override float Eval(XprContext ctx)
        {
            return _value.Eval(ctx);
        }

        public override string ToString()
        {
            return $"({_value})";
        }
    }
}
