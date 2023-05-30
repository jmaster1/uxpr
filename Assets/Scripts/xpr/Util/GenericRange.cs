namespace xpr.Util
{
    public class GenericRange<T>
    {
        public readonly T Src;

        public int From, Length;

        public GenericRange(T src, int cur)
        {
            Src = src;
            From = cur;
            Length = 0;
        }

        public override string ToString()
        {
            return "" + From + ":" + Length;
        }

        public GenericRange<T> SetTo(int cur)
        {
            Length = cur - From;
            return this;
        }
    }

}
