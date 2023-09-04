using System;

namespace Game.Source.Inventory
{
    public class InventorySlot : IInventorySlot , IVeiwInventorySlot
    {
        public Action<int, IVeiwInventorySlot> IsItemUpdate { get; set; }
        public IItem Item { get; private set; }
        public Type IteamType { get; }
        public int Amount { get; private set; }
        public int Capacity { get; }
        public int IndexInQueueOrder { get; private set;}
        public bool IsFull { get; }
        public bool IsEmpty { get; }

        public InventorySlot(int indexInQueueOrder)
        {
            IndexInQueueOrder = indexInQueueOrder;
        }
        
        public void SetIteam(IItem newIteam)
        {
            if (Item != null)
                Clear();
            
            Item = newIteam;
            newIteam.Swap += SetIteam;
        }
        
        public void Clear()
        {
            Item.Swap = null;
            Item = null;
            Amount = 0;
        }

        public void IncreaseNumber(int amount)
        {
            Amount += amount;
        }

        public void ReduceNumber(int amount)
        {
            Amount -= amount;
        } 
    }
}