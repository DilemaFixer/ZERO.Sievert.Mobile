using System;
using System.Threading.Tasks;
using Game.Effects;
using Game.Entities;

namespace Game
{
    public class DamagEf : NegativeEffects<Entity>
    {
        
        private int _delayInSeconds = 4000;
        public override bool IsEffectDeactivate { get; protected set; }
        public override async Task ApplyEffect(Entity Target)
        {
            while (!IsEffectDeactivate)
            {
                Target.ApplyDamag(10 , 10);
                await Task.Delay(_delayInSeconds);
            }
        }
    }
}