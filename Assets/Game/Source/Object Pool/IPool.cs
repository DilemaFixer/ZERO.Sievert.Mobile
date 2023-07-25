namespace Game.Object_Pool
{
    public interface IPool<T>
    {
        T Pull();
        void Push(T Item);
    }
}