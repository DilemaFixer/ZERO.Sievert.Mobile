using System;
using UnityEngine;

public abstract class IItem
{
    public IItem(ItemData data, int amount) {
        this.Data = data;
        this.Amount = amount;
    }
    [field: SerializeField]public int Amount { get; set; }
    [field: SerializeField]public ItemData Data { get; private set; }
    public abstract event Action OnChange;
    public abstract void Add(IItem item);
    public abstract IItem DivideItem(int ratio1, int ratio2);

    public abstract int ExtractCount(int count);
}
