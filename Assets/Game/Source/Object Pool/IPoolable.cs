
using System;

namespace Game.Object_Pool
{
    public interface IPoolable<T>
    {
        bool Activity { get; }
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
        void SetActivity(bool Activity);
    }
}