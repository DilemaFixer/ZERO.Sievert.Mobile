using System.Threading.Tasks;

namespace Game.Effects
{
    public interface IEffect<T>
    {
        Task ApplyEffect(T Target);
        void DeactivateEffect();
    }
}