using System;
using Game.Entities;

namespace Game.Source
{
    public abstract class IntelligentEntity : Entity
    {
        protected Weapon.Weapon _currentWeapon;
        public abstract void Attack();
        public void SetWeapon(Weapon.Weapon weapon)
        {
            if (weapon != null)
            {
                _currentWeapon = weapon;
            }
            else
            {
                throw new NullReferenceException("New weapon is null");
            }
        }
    }
}