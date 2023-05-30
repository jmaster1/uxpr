using System.Collections.Generic;
using Unity;
using UnityEngine;

namespace xpr.Util.Math
{
    public class FloatArrayHistory : GenericEntity
    {
        private readonly List<float[]> _history = new();
    
        public int ArraySize => _history.Count > 0 ? _history[0].Length : 0;
    
        public void Add(float[] data)
        {
            if (_history.Count > 0)
            {
                var l = ArraySize;
                Assert(l == data.Length);
            }
            _history.Add(data);
        }

        public IData2DProvider CreateAverageProvider(int size)
        {
            return new DefaultData2DProvider(
                () => ArraySize,
                i => new Vector2(i, Avg(i, size))
            );
        }
    
        public IData2DProvider CreateHistoryProvider(int index, int size)
        {
            return new DefaultData2DProvider(
                () => _history.Count,
                i => new Vector2(i, _history[i][index])
            );
        }

        private float Avg(int index, int size)
        {
            var historyCount = _history.Count;
            var processed = 0;
            var avg = 0f;
            for (var i = 0; i < size; i++)
            {
                var hi = historyCount - i - 1;
                if (hi < 0)
                {
                    break;
                }
                avg += _history[hi][index];
                processed++;
            }
            avg /= processed;
            return avg;
        }
        
        private float Avg(int index, int length, int size)
        {
            // TODO: length
            var historyCount = _history.Count;
            var processed = 0;
            var avg = 0f;
            for (var i = 0; i < size; i++)
            {
                var hi = historyCount - i - 1;
                if (hi < 0)
                {
                    break;
                }
                avg += _history[hi][index];
                processed++;
            }
            avg /= processed;
            return avg;
        }
    }
}
