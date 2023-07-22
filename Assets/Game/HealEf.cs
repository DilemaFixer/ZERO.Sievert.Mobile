using System.Threading.Tasks;
using Game.Effects;
using Game.Entities;

namespace Game
{
    public class HealEf : PositiveEffects<Entity>
    {
        private int _healingAmount = 2;
        private int _delayInSeconds = 4000;
        
        public override bool IsEffectDeactivate { get; protected set; }
        public override async Task ApplyEffect(Entity Target)
        {
            while (!IsEffectDeactivate)
            {
                Target.Heal(_healingAmount);
                await Task.Delay(_delayInSeconds);
            }
        }
        
    }
}