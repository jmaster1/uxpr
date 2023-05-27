using UnityEngine;
using UnityEngine.Serialization;
using Xpr.xpr;

namespace xpr.Unity
{

    public class UXprEmitter : MonoBehaviour
    {
        private static XprContext Ctx => UXprContext.Context;

        public GameObject particle;
        
        public UXpr particleCount;
        
        public UXprProperty[] particleProperties;

        private int generatedCount;
        
        private XprContext ctx = UXprContext.Create();

        private void Awake()
        {
            ctx.Funcs0["generatedcount"] = () => generatedCount;
            ctx.Funcs0["particlecount"] = () => particleCount.Eval(ctx);
        }

        private void Update()
        {
            while (generatedCount < particleCount.Eval(ctx))
            {
                CreateParticle();
                generatedCount++;
            }
        }

        private void CreateParticle()
        {
            var e = Instantiate(particle);
            particleProperties.Apply(ctx, e);
        }
    }

}