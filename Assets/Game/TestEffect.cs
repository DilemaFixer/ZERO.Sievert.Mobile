using Game.Effects;
using Game.Entities.Player;
using UnityEngine;

namespace Game
{
    public class TestEffect : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [ContextMenu("Вызвать SetEffect")]
        public void SetHealtEffect()
        {
            HealEf healEf = new HealEf();
            _player.ApplyEffect(healEf);
        }
        
        public void SetDamagEffect()
        {
            DamagEf damagEf = new DamagEf();
            _player.ApplyEffect(damagEf);
        }
        
        public void resetEffect()
        {
            _player.ClearCertainEffect(SpacerForEffect.Positive);
        }
    }
}