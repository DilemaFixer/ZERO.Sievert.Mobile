using Game.Source;
using UnityEngine;

namespace Game.Entities.Player
{
    public class Player : IntelligentEntity
    {
        [SerializeField] private Weapon.Weapon _weapon;

        public override void ApplyDamag(int damag, int penetrationCapacity)
        {
            int currentDamag = damag - (_resistance - penetrationCapacity);
            Debug.Log(currentDamag);
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
    }
}