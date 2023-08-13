using System.Threading.Tasks;
using Game.Weapon.Projectiles;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class Firearms<T> : Weapon where T : Projectile
    {
        [field: SerializeField] public int _maxProjectileInClip { get; protected set; }
        [SerializeField] protected int _rechargingTime;
        [SerializeField] protected T _projectilePrefab;

        protected AmmoHolder _ammoHolder = new AmmoHolder(9);

        public bool IsRechargingNow { get; protected set; } = false;
        public int СurrentCountProjectileInClip { get; protected set; }


        public override bool HasProjectile()
        {
            return СurrentCountProjectileInClip > 0;
        }

        public virtual async void Recharging()
        {
            IsRechargingNow = true;
            int projectileAmount;
            projectileAmount = _ammoHolder.GetMaximumAmountAvailableProjectile(_maxProjectileInClip);
            Debug.Log(projectileAmount);
            if (projectileAmount > 0)
            {
                for (int i = 0; i < projectileAmount; i++)
                {
                    await Task.Delay(_rechargingTime * 1000);
                    СurrentCountProjectileInClip++;
                }
            }
            else
            {
                Debug.Log("0 projectile in iventory");
            }

            IsRechargingNow = false;
        }

        protected override async void AttackDelay()
        {
            IsThereDelayedAttackNow = true;
            await Task.Delay(_attackDelayTime * 1000);
            IsThereDelayedAttackNow = false;
        }
    }
}