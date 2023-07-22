using UnityEngine;

namespace Game.Weapon.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected int _longFlightTime;
        [SerializeField] private int _penetrationCapacity;
    }
}