﻿namespace Xpr.xpr.Util
{
    /// <summary>
    /// generic interface with id support
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdAware<out T>
    {
        T GetId();
    }
}