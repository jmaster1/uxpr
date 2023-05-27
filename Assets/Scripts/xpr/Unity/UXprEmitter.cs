using UnityEngine;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprEmitter : MonoBehaviour
    {
        public GameObject particle;
        
        public UXpr particleCount;
        
        public UXpr rate;

        private float _nextCreateTime;
        
        public UXprProperty[] particleProperties;

        private int _generatedCount;
        
        private readonly XprContext ctx = UXprContext.Create();
        private float _lastCreateTime;

        private void Awake()
        {
            ctx.Funcs0["generatedcount"] = () => _generatedCount;
            ctx.Funcs0["particlecount"] = () => particleCount.Eval(ctx);
        }

        private void Update()
        {
            var rt = rate.Eval(ctx);
            while (_generatedCount < particleCount.Eval(ctx))
            {
                var nextCreateTime = _lastCreateTime + 1 / rt;
                if (nextCreateTime > Time.time)
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
            var e = Instantiate(particle);
            particleProperties.Apply(ctx, e);
            e.SetActive(true);
            _lastCreateTime = Time.time;
        }
    }

}