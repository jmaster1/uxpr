using System;
using UnityEngine;
using xpr;
using xpr.Unity;
using Xpr.xpr;

namespace Unity
{

    public interface IData2DProvider
    {
        int GetCount();

        Vector2 Get(int index);
    }

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

    public class Plotter : MonoBehaviour
    {
        public IData2DProvider Provider;
        
        public UXpr transformX, transformY;

        public Color color;

        private readonly XprContext _ctx = UXprContext.Create();

        private Vector2 _value;
        
        private void Awake()
        {
            _ctx.Funcs0["x"] = () => _value.x;
            _ctx.Funcs0["y"] = () => _value.y;
        }

        private void Update()
        {
            var txPos = transform.position;
            var n = Provider.GetCount();
            Vector3 prevPos = default;
            var maxX = 0f;
            for (var i = 0; i < n; i++)
            {
                _value = Provider.Get(i);
                var x = transformX.Eval(_ctx);
                var y = transformY.Eval(_ctx);
                maxX = Mathf.Max(maxX, x);
                var valuePos = new Vector3(x + txPos.x, y + txPos.y, txPos.z);
                if (i > 0)
                {
                    Debug.DrawLine(prevPos, valuePos, color);    
                }
                prevPos = valuePos;
            }
            
            Debug.DrawLine(txPos, txPos + new Vector3(maxX, 0, 0), color);
        }
    }

}
