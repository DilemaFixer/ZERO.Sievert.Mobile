using System.Threading.Tasks;

namespace Game.Effects
{
    public interface IEffect<T> where T : IEffectable<T>
    {
        Task ApplyEffect(T Target);
        void DeactivateEffect();
    }
}