using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp.Generators
{
    class GenerateBySeconds : Generator
    {
        private const float DELAY_IN_SECONDS = 1f;

        public override event Action OnGenerated;
        
        public override IEnumerator StartGenerate()
        {
            while (true)
            {
                yield return new WaitForSeconds(DELAY_IN_SECONDS);
                OnGenerated?.Invoke();
            } 
        }
    }
}