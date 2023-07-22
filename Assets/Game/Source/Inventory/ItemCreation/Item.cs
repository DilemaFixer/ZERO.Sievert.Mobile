using System;
using UnityEngine;


public class Item : IItem
{
    public Item(ItemData data, int amount) : base(data, amount) { }
   
    public override event Action OnChange;

    public override void Add(IItem item)
    {
        int maxStack = item.Data.maxStack;
        Amount += item.ExtractCount(maxStack - Amount);
        OnChange?.Invoke();
    }

    public override IItem DivideItem(int ratio1, int ratio2)
    {
        throw new System.NotImplementedException();
    }
    public override int ExtractCount(int count) // ¬озвращает количество извлеченных предметов по заданному количеству
    {
        int result = Amount > count ? count : Amount;
        Amount -= result;
        OnChange?.Invoke();
        return result;

    }
   
}
