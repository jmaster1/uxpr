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
        sz,
        rx,
        ry,
        rz
    }
    
    public static class UnityPropertyEx
    {

        public static Action<GameObject, float> GetSetter(this UnityProperty p)
        {
            return p switch
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
                UnityProperty.rx => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation =  Quaternion.Euler(val, pos.y, pos.z);
                },
                UnityProperty.ry => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation = Quaternion.Euler(pos.x, val, pos.z);
                },
                UnityProperty.rz => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation = Quaternion.Euler(pos.x, pos.y, val);
                },
                _ => throw new ArgumentOutOfRangeException(nameof(p), p, null)
            };
        }
    }
}
