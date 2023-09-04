using System;

namespace Game.Source.Inventory
{
    public interface IInventorySlot
    {
        Action<int, IVeiwInventorySlot> IsItemUpdate { get; set; }
        IItem Item { get; }
        Type IteamType { get; }
        
        int Amount { get; }
        int Capacity { get; }
        int IndexInQueueOrder { get; }
        
        bool IsFull { get; }
        bool IsEmpty { get; }

        void SetIteam(IItem newIteam);
        void Clear();
        void IncreaseNumber(int amount);
        void ReduceNumber(int amount);
    }
}