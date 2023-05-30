using System;
using UnityEngine;

namespace Components.Unity
{

    public class DefaultData2DProvider : IData2DProvider
    {
        private readonly Func<int> _count;
        
        private readonly Func<int, Vector2> _value;

        public DefaultData2DProvider(Func<int> count, Func<int, Vector2> value)
        {
            _count = count;
            _value = value;
        }

        public int GetCount()
        {
            return _count.Invoke();
        }

        public Vector2 Get(int index)
        {
            return _value.Invoke(index);
        }
    }

}