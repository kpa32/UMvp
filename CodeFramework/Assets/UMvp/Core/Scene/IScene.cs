using UnityEngine;
using System.Collections;

namespace Game
{
    public abstract class IScene
    {
        public abstract void Initial();

        public virtual void Load() { }

        public virtual void UnLoad() { }

        public virtual void Update() { }

        public abstract void Exit();
        
    }
}
