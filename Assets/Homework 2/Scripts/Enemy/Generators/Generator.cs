using System;
using System.Collections;

namespace ShootEmUp.Generators
{
    abstract class Generator
    {
        public abstract event Action OnGenerated;
        
        public abstract IEnumerator StartGenerate();
    }
}