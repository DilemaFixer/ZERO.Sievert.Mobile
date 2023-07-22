using System.Threading.Tasks;
using UnityEngine;

namespace Game.Effects
{
    public abstract class Effect<Y> : IEffect<Y>
    {
        public abstract bool IsEffectDeactivate { get; protected set; }
        public abstract Task ApplyEffect(Y Target);
        public void DeactivateEffect()
        {
            IsEffectDeactivate = true;
        }
    }
}