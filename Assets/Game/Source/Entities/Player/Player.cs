using System;
using System.Collections.Generic;
using Game.Effects;
using Game.Weapon;
using UnityEngine;

namespace Game.Entities.Player
{
    public class Player : Entity 
    {
        public override void ApplyDamag(int damag , int penetrationCapacity)
        {
            int currentDamag = damag - (_resistance - penetrationCapacity);
         
        }

        public override void Attack()
        {
            if(_currentWeapon.IsRecharging && _currentWeapon == null)
                return;
            
            if (_currentWeapon.HasAmmo())
            {
                _currentWeapon.Attack();
            }
            else
            {
                _currentWeapon.Recharging();
            }
        }

       
    }
}