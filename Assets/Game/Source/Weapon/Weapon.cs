using UnityEngine;

namespace Game.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _recharging;
        [SerializeField] protected int _countOfProjectile;
       
        public abstract void Shoot();
    }
}