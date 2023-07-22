using System;
using System.Collections.Generic;
using Game.Effects;
using UnityEngine;

namespace Game.Entities.Player
{
    public class Player : Entity 
    {
        public override int _health { get; protected set; }
        public override List<IEffect<Entity>> _effects { get; set; } = new List<IEffect<Entity>>();

        public override void ApplyDamag(int Damag , int PenetrationCapacity)
        {
            Debug.Log($"Take {Damag} damge");
           // int currentDamag = Damag - (_resistance - PenetrationCapacity);
        }

        public override void Attack()
        {
            
        }
        
    }
}