using System.Collections.Generic;

namespace Game.Source.Inventory
{
    public interface IInventoryRenderer
    {
        public void Render(List<IVeiwInventorySlot> Items);
        public void UpdateSlot( int index , IVeiwInventorySlot Items);
    }
}