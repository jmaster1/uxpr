using System;
using xpr.Token;
using xpr.Util;
using Xpr.xpr;
using Xpr.xpr.Token;
using Xpr.xpr.Val;

namespace xpr.Val
{

    /**
     * base class for Xpr value provider
     */
    public abstract class XprVal : GenericEntity
    {
        public abstract XprValType GetValType();

        public bool Is(XprValType type)
        {
            return type == GetValType();
        }

        public abstract float Eval(XprContext ctx);

        public XprToken RequireToken(XprToken token, XprTokenType type)
        {
            if (token == null || token.Type != type)
            {
                throw new ArgumentException($"{this} requires token of type {type}, got: {token}");
            }

            return token;
        }
    }

}