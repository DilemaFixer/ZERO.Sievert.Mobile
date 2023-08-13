using System;
using System.Collections.Generic;
using Game.Effects;
using UnityEngine;

namespace Game.Entities
{
    public abstract class Entity : MonoBehaviour, IEffectable<Entity>
    {
         
        [SerializeField] protected int _maxHealth;
        [field: SerializeField] public int _resistance { get; protected set; }
        public List<IEffect<Entity>> _effects { get; protected set; }
        public int _health { get; protected set; }
        
        public abstract void ApplyDamag(int damag, int penetrationCapacity);
        
        
        private void Start()
        {
            _health = _maxHealth;
        }

        public void Heal(int amount)
        {
            _health += amount;
        }

        public void ClearEffect(Effect<Entity> effectType)
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                if (_effects[i].GetType() == effectType.GetType())
                {
                    var effect = _effects[i];
                    effect.DeactivateEffect();
                    _effects.Remove(effect);
                }
            }
        }
        
        public void ClearCertainEffect(SpacerForEffect effectType)
        {
            List<Effect<Entity>> effectsToRemove = new List<Effect<Entity>>();
            foreach (Effect<Entity> effect in _effects)
            {
                if (effectType == SpacerForEffect.All)
                {
                    effect.DeactivateEffect();
                    effectsToRemove.Add(effect);
                }
                else if (effectType == SpacerForEffect.Positive && effect is PositiveEffects<Entity> positiveEffect)
                {
                    positiveEffect.DeactivateEffect();
                    effectsToRemove.Add(effect);
                }
                else if (effectType == SpacerForEffect.Negative && effect is NegativeEffects<Entity> negativeEffect)
                {
                    negativeEffect.DeactivateEffect();
                    effectsToRemove.Add(effect);
                }
            }

            foreach (var effectToRemove in effectsToRemove)
            {
                _effects.Remove(effectToRemove);
            }
        }

        public void ApplyEffect(Effect<Entity> effect)
        {
            _effects.Add(effect);
            effect.ApplyEffect(this);
        }
    }
}