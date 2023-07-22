using System;
using System.Collections.Generic;
using Game.Effects;
using UnityEngine;

namespace Game.Entities
{
    public abstract class Entity : MonoBehaviour , IEffectable<Entity>
    {
        [SerializeField] protected int _maxHealth;

        public abstract List<IEffect<Entity>> _effects { get; set; } 
        public abstract int _health { get; protected set; }
        protected int _resistance { get; private set; }

        private void Start()
        {
            _health = _maxHealth;
        }

        public void Heal(int Amount)
        {
            Debug.Log(Amount + " i was heal");
           // _health += Amount
        }
        public abstract void ApplyDamag(int Damag , int PenetrationCapacity);
        public abstract void Attack();
        

        public void ClearEffect(Effect<Entity> EffectType)
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                if (_effects[i].GetType() == EffectType.GetType())
                {
                    var effect = _effects[i];
                    effect.DeactivateEffect();
                    _effects.Remove(effect);
                }
                Debug.Log("iteration");
            }
        }

        public void ClearCertainEffect(SpacerForEffect effectType)
        {
            _effects.RemoveAll(effect =>
                {
                    switch (effectType)
                    {
                        case SpacerForEffect.All:
                            return true;
                        case SpacerForEffect.Positive when effect is PositiveEffects<Entity> positiveEffect:
                            positiveEffect.DeactivateEffect();
                            return true;
                        case SpacerForEffect.Negative when effect is NegativeEffects<Entity> negativeEffect:
                            negativeEffect.DeactivateEffect();
                            return true;
                        default:
                            return false;
                    }
                });
        }
        
        public void ApplyEffect(Effect<Entity> Effect)
        {
            _effects.Add(Effect);
            Effect.ApplyEffect(this);
        }
    }
}