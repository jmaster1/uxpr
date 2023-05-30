using UnityEngine;

namespace Components.Unity
{

    public interface IData2DProvider
    {
        int GetCount();

        Vector2 Get(int index);
    }

}