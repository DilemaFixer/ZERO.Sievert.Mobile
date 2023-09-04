using System;

namespace Game.Source.Inventory
{
    public interface IItem
    {
        public Action<IItem> Swap { get; set; }
        public InventoryIteamData Data { get; }
        public Type Type { get; }
        public int MaxAmountInSlot { get; }
        IItem Clone();
    }
}