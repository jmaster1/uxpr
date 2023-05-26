namespace Xpr.xpr.Token
{

    public struct SrcRange
    {
        public readonly string Src;

        public int From, Length;

        public SrcRange(string src, int cur)
        {
            Src = src;
            From = cur;
            Length = 0;
        }

        public override string ToString()
        {
            return "" + From + ":" + Length;
        }

        public SrcRange SetTo(int cur)
        {
            Length = cur - From;
            return this;
        }
    }

}
