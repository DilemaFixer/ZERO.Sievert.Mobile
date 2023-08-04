using Game.Weapon.Projectiles;
using UnityEngine;

namespace Game.Weapon
{
    public class Pistol : Firearms<PistolProjectile>
    {
        public override void Attack()
        {
          var projectile = Instantiate(_projectilePrefab, _startAttackPoint.position, Quaternion.identity);
          projectile.SetVectorMove(Vector3.right);
            _currentCountProjectileInClip -= 1;
        }

        public override bool HasAmmo()
        {
            return _currentCountProjectileInClip > 0;
        }
    }
}