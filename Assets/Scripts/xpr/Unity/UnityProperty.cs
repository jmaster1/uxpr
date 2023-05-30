using System;
using UnityEngine;

namespace xpr.Unity
{

    public enum UnityProperty
    {
        X,
        Y,
        Z,
        Sx,
        Sy,
        Sz,
        Rx,
        Ry,
        Rz,
        CR,
        Cg,
        Cb,
        Ca
    }
    
    public static class UnityPropertyEx
    {

        public static Action<GameObject, float> GetSetter(this UnityProperty p)
        {
            return p switch
            {
                UnityProperty.X => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(val, pos.y, pos.z);
                },
                UnityProperty.Y => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(pos.x, val, pos.z);
                },
                UnityProperty.Z => (go, val) =>
                {
                    var pos = go.transform.localPosition;
                    go.transform.localPosition = new Vector3(pos.x, pos.y, val);
                },
                UnityProperty.Sx => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(val, pos.y, pos.z);
                },
                UnityProperty.Sy => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, val, pos.z);
                },
                UnityProperty.Sz => (go, val) =>
                {
                    var pos = go.transform.localScale;
                    go.transform.localScale = new Vector3(pos.x, pos.y, val);
                },
                UnityProperty.Rx => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation =  Quaternion.Euler(val, pos.y, pos.z);
                },
                UnityProperty.Ry => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation = Quaternion.Euler(pos.x, val, pos.z);
                },
                UnityProperty.Rz => (go, val) =>
                {
                    var pos = go.transform.rotation;
                    go.transform.rotation = Quaternion.Euler(pos.x, pos.y, val);
                },
                UnityProperty.CR => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.r = val;
                    sprite.color = color;
                },
                UnityProperty.Cg => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.g = val;
                    sprite.color = color;
                },
                UnityProperty.Cb => (go, val) =>
                {
                    var sprite = go.GetComponent<SpriteRenderer>();
                    var color = sprite.color;
                    color.b = val;
                    sprite.color = color;
                },
                UnityProperty.Ca => (go, val) =>
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
