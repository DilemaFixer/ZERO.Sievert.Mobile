using Game.Weapon.Projectiles;
using UnityEngine;

namespace Game.Weapon
{
    public class Pistol : Firearms<PistolProjectile>
    {
        public override void Attack()
        {
            if (IsThereDelayedAttackNow || IsRechargingNow)
            {
                return;
            }

            if (СurrentCountProjectileInClip == 0)
            {
                Recharging();
                return;
            }
            
            var projectile = Instantiate(_projectilePrefab, _startAttackPoint.position, Quaternion.identity);
            projectile.SetVectorMove(Vector3.right);
            СurrentCountProjectileInClip -= 1;
            AttackDelay();
        }
    }
}