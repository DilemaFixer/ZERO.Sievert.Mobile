using System;
using Game.Source;
using UnityEngine;

namespace Game.Entities.Player
{
    public class Player : IntelligentEntity
    {
        [SerializeField] private Weapon.Weapon _weapon;
        [SerializeField] private PlayermMovement _playermMovement;
        public override void ApplyDamag(int damag, int penetrationCapacity)
        {
            int currentDamag = damag - (_resistance - penetrationCapacity);
            Debug.Log(currentDamag);
        }
        public void SetJoystic(VariableJoystick variableJoystick)
        {
            _playermMovement.SetJoystic(variableJoystick);
        }
        
        public override void Attack()
        {
            _currentWeapon = _weapon;
            if (_currentWeapon == null)
            {
                return;
            }

            _currentWeapon.Attack();
        }

        private void OnDestroy()
        {
            Debug.Log("Saving");
        }
    }
}