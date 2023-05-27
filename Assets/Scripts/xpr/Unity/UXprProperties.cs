using System;
using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprProperties : MonoBehaviour
    {
        private static XprContext Ctx => UXprContext.Context;

        public UXprProperty[] properties;

        private void Awake()
        {
            Ctx.Funcs0["x"] = () => transform.position.x;
            Ctx.Funcs0["y"] = () => transform.position.y;
            Ctx.Funcs0["z"] = () => transform.position.z;

            var pos = transform.position;
            Ctx.Funcs0["x0"] = () => pos.x;
            Ctx.Funcs0["y0"] = () => pos.y;
            Ctx.Funcs0["z0"] = () => pos.z;
            var sc = transform.localScale;
            Ctx.Funcs0["sx0"] = () => sc.x;
            Ctx.Funcs0["sy0"] = () => sc.y;
            Ctx.Funcs0["sz0"] = () => sc.z;
            var rot = transform.rotation.eulerAngles;
            Ctx.Funcs0["rx0"] = () => rot.x;
            Ctx.Funcs0["ry0"] = () => rot.y;
            Ctx.Funcs0["rz0"] = () => rot.z;
            properties.Prepare(Ctx, gameObject);
        }

        private void Update()
        {
            properties.Apply(Ctx, gameObject);
        }
    }
}