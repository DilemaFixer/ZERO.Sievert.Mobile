using System.Threading.Tasks;

namespace Game.Effects
{
    public abstract class Effect<Y> : IEffect<Y> where Y : IEffectable<Y>
    {
        public abstract bool IsEffectDeactivate { get; protected set; }
        public abstract Task ApplyEffect(Y Target);
        public void DeactivateEffect()
        {
            IsEffectDeactivate = true;
        }
    }
}