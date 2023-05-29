using System.Collections.Generic;
using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public abstract class AbstractUXprEmitter<T> : MonoBehaviour
    {
        /// <summary>
        /// particle template
        /// </summary>
        public T particle;
        
        public UXpr particleCount;
        
        public UXpr rate;

        private float _nextCreateTime;
        
        public UXprProperty[] particleProperties;

        private int _generatedCount;
        
        private readonly XprContext ctx = UXprContext.Create();
        private float _lastCreateTime;

        public readonly List<T> Particles = new();

        private void Awake()
        {
            ctx.Funcs0["generatedcount"] = ctx.Funcs0["i"] = () => _generatedCount;
            ctx.Funcs0["particlecount"] = ctx.Funcs0["n"] = () => particleCount.Eval(ctx);
            ctx.Funcs0["generatednormal"] = () => _generatedCount / particleCount.Eval(ctx);
        }

        private void Update()
        {
            var t = Time.time;
            var rateVal = rate.Eval(ctx);
            while (_generatedCount < particleCount.Eval(ctx))
            {
                var nextCreateTime = rateVal > 0 ? _lastCreateTime + 1 / rateVal : t;
                if (nextCreateTime > t)
                {
                    break;
                }

                CreateParticle();
                _lastCreateTime = nextCreateTime;
                _generatedCount++;
            }
        }

        private void CreateParticle()
        {
            var e = Clone();
            var go = GetGameObject(e);
            go.name = _generatedCount.ToString();
            particleProperties.Apply(ctx, go);
            go.SetActive(true);
            _lastCreateTime = Time.time;
            Particles.Add(e);
        }

        protected abstract GameObject GetGameObject(T e);

        protected abstract T Clone();
    }
}