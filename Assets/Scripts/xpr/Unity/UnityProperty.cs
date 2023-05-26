using System;
using UnityEngine;

namespace xpr.Unity
{

    public enum UnityProperty
    {
        x,
        y,
        z,
        sx,
        sy,
        sz
    }
    
    public static class UnityPropertyEx
    {

        public static Action<GameObject, float> GetSetter(this UnityProperty val)
        {
            return val switch
            {
                UnityProperty.x => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(val, pos.y, pos.z);
                },
                UnityProperty.y => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(pos.x, val, pos.z);
                },
                UnityProperty.z => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(pos.x, pos.y, val);
                },
                UnityProperty.sx => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(val, pos.y, pos.z);
                },
                UnityProperty.sy => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, val, pos.z);
                },
                UnityProperty.sz => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, pos.y, val);
                },
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }
}
