using System;
using UnityEngine;

namespace Xpr.xpr.Unity
{

    public enum GOProperty
    {
        x,
        y,
        z,
        sx,
        sy,
        sz
    }
    
    public static class GOPropertyEx
    {

        public static Action<GameObject, float> GetSetter(this GOProperty val)
        {
            return val switch
            {
                GOProperty.x => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(val, pos.y, pos.z);
                },
                GOProperty.y => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(pos.x, val, pos.z);
                },
                GOProperty.z => (go, val) =>
                {
                    var pos = go.transform.position;
                    go.transform.position = new Vector3(pos.x, pos.y, val);
                },
                GOProperty.sx => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(val, pos.y, pos.z);
                },
                GOProperty.sy => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, val, pos.z);
                },
                GOProperty.sz => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, pos.y, val);
                },
                _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
            };
        }
    }
}