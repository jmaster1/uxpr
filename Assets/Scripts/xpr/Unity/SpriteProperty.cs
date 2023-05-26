using System;
using UnityEngine;

namespace Xpr.xpr.Unity
{

    public enum SpriteProperty
    {
        colorR,
        y,
        z,
        sx,
        sy,
        sz
    }
    
    public static class SpritePropertyEx
    {

        public static Action<GameObject, float> GetSetter(this SpriteProperty val)
        {
            return val switch
            {
                
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }
}