using Game.Entities;
using UnityEngine;

namespace Game.Source.Enemy
{
    public class Enemy : IntelligentEntity
    {
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyDamag(int damag, int penetrationCapacity)
        {
            int currentDamag = damag - (_resistance - penetrationCapacity);
        }
    }
}