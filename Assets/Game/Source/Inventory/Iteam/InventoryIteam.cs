using System;

namespace Game.Source.Inventory
{
    public class InventoryIteam : IItem
    {
        public Action<IItem> Swap { get; set; }
        public InventoryIteamData Data { get; private set; }
        public Type Type { get { return GetType(); } }
        public int MaxAmountInSlot { get { return Data.MaxCountInCall; } }
        public IItem Clone()
        {
            return this.Clone();
        }
    }
}