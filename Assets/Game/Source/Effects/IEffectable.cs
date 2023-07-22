using System;
using System.Collections.Generic;

namespace Game.Effects
{
    public interface IEffectable<T>
    {
        List<IEffect<T>> _effects { get; set; }

        void ClearEffect(Effect<T> EffectType);
        void ClearCertainEffect(SpacerForEffect EffectType);
        void ApplyEffect(Effect<T> Effect);
    }
}