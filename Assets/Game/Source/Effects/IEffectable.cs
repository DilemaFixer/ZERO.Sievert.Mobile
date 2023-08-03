using System;
using System.Collections.Generic;

namespace Game.Effects
{
    public interface IEffectable<T> where T : IEffectable<T>
    {
        List<IEffect<T>> _effects { get; }

        void ClearEffect(Effect<T> effectType);
        void ClearCertainEffect(SpacerForEffect EffectType);
        void ApplyEffect(Effect<T> effect);
    }
}