using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _startAttackPoint;
        [SerializeField] protected int _attackDelayTime;

        public bool IsThereDelayedAttackNow { get; protected set; } = false;

        public abstract void Attack();
        protected abstract void AttackDelay();

        public virtual bool HasProjectile()
        {
            return true;
        }
    }
}