using System.Collections.Generic;
using Unity;
using UnityEngine;
using xpr.Util;

public class FloatArrayHistory : GenericEntity
{
    private List<float[]> history = new();
    
    public int ArraySize => history.Count > 0 ? history[0].Length : 0;
    
    public void Add(float[] data)
    {
        if (history.Count > 0)
        {
            var l = ArraySize;
            Assert(l == data.Length);
        }
        history.Add(data);
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
            () => history.Count,
            i => new Vector2(i, history[i][index])
        );
    }

    private float Avg(int index, int size)
    {
        var historyCount = history.Count;
        var processed = 0;
        var avg = 0f;
        for (var i = 0; i < size; i++)
        {
            var hi = historyCount - i - 1;
            if (hi < 0)
            {
                break;
            }
            avg += history[hi][index];
            processed++;
        }
        avg /= processed;
        return avg;
    }
}
