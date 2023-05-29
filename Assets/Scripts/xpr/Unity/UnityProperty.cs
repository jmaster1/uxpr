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
        rz,
        cr,
        cg,
        cb,
        ca
    }
    
    public static class UnityPropertyEx
    {

        public static Action<GameObject, float> GetSetter(this UnityProperty p)
        {
            return p switch
            {
                UnityProperty.x => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(val, pos.y, pos.z);
                },
                UnityProperty.y => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(pos.x, val, pos.z);
                },
                UnityProperty.z => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(pos.x, pos.y, val);
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
                UnityProperty.cr => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.r = val;
                    sprite.color = color;
                },
                UnityProperty.cg => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.g = val;
                    sprite.color = color;
                },
                UnityProperty.cb => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.b = val;
                    sprite.color = color;
                },
                UnityProperty.ca => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.a = val;
                    sprite.color = color;
                },
                _ => throw new ArgumentOutOfRangeException(nameof(p), p, null)
            };
        }
    }
}
