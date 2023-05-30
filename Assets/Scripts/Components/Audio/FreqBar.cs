using System;
using System.Collections.Generic;
using UnityEngine;
using xpr.Unity;

namespace Components.Audio
{

    public class FreqBar : MonoBehaviour
    {
        public Au au;

        public GameObjectUXprEmitter barsEmitter;

        public List<GameObject> Cells => barsEmitter.Particles;

        private void Start()
        {
            foreach (var cell in Cells)
            {
                
            }
        }
    }
}
