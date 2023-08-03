using Game.Weapon.Projectiles;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class Firearms : Weapon
    {
        [SerializeField] public int _maxProjectileInClip { get; private set; }
        [SerializeField] protected Projectile _projectilePrefab;
        public AmmoHolder _ammoHolder = new AmmoHolder(10);
        public int _currentCountProjectileInClip { get; protected set; }
        
        protected bool HasProjectilesInInventory()
        {
            if (_ammoHolder.HasAmmo(_maxProjectileInClip))
            {
                return true;
            }

            return false;
        }
        
        public override void Recharging()
        {
            if (HasProjectilesInInventory())
            {
                _ammoHolder.ConsumeAmmo(_maxProjectileInClip);
                _currentCountProjectileInClip = _maxProjectileInClip;
            }
            else
            {
                Debug.Log("0 projectile in iventory");
            }
        }
    }
}