using System;
using UnityEngine;

namespace Game.Weapon
{
    public class Pistol : Firearms
    {
        public override void Attack()
        {
            Instantiate(_projectilePrefab, _startAttackPoint.position, Quaternion.identity);
            _currentCountProjectileInClip -= 1;
        }

        public override bool HasAmmo()
        {
            return _currentCountProjectileInClip > 0;
        }
    }
}