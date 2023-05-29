#nullable enable
using System;
using Xpr.xpr.Math;
using Xpr.xpr.Util;

namespace Xpr.xpr.Token
{

    /**
     * represents xpr token parsed from character stream
     */
    public class XprToken : GenericEntity
    {
        public readonly XprTokenType Type;

        private readonly object? _value;

        private readonly SrcRange _range;

        public XprToken(XprTokenType type, object? value, SrcRange range)
        {
            Type = type;
            _value = value;
            _range = range;
        }

        public float NumberValue => (float) (_value ?? float.NaN);

        public string? StringValue => (string) (_value ?? null)!;

        public MathOperator MathOperator => (MathOperator) ((_value ?? default) ?? throw new InvalidOperationException());

        public bool Is(XprTokenType type)
        {
            return type == Type;
        }

        public override string ToString()
        {
            return Type + "=" + _value + " (" + _range + ")";
        }
    }
}
