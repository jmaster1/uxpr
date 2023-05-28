using UnityEngine;

namespace xpr.Unity
{

    public class MonobehUXprEmitter : AbstractUXprEmitter<MonoBehaviour>
    {
        protected override GameObject GetGameObject(MonoBehaviour e)
        {
            return e.gameObject;
        }

        protected override MonoBehaviour Clone()
        {
            return Instantiate(particle);
        }
    }
}
