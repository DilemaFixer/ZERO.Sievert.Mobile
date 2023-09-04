namespace Game.Source.Inventory
{
    public interface IVeiwInventorySlot
    {
        int Amount { get; }
        IItem Item { get; }
        bool IsFull { get; }
    }
}