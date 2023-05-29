using UnityEngine;

namespace xpr.Unity
{

    public class GameObjectUXprEmitter : AbstractUXprEmitter<GameObject>
    {
        protected override GameObject GetGameObject(GameObject e)
        {
            return e;
        }

        protected override GameObject Clone()
        {
            return Instantiate(particle, transform);
        }
    }
}
