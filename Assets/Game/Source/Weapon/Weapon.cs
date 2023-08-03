using Game.Weapon.Projectiles;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _recharging;
        [SerializeField] protected Transform _startAttackPoint;
        
        public bool IsRecharging { get; protected set; }

        public abstract void Attack();
        public abstract void Recharging();
        
        public virtual bool HasAmmo()
        {
            return true;
        }
    }
}