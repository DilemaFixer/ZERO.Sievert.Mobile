using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : ISlot
{
    public override ItemView Put(ItemView itemView)
    {
        
        if(!IsEmpty)
        {
            if(itemView._item.Data.Id == equipedItem._item.Data.Id)
            {
                equipedItem._item.Add(itemView._item);
                if (itemView._item.Amount <= 0) return null;
                return itemView;
            }
           
        }
        ItemView extractedItem = equipedItem;
        equipedItem = itemView;
        equipedItem.transform.position = transform.position;
        equipedItem.transform.parent = transform;
        if (equipedItem == null) IsEmpty = true;
        else
        {
            IsEmpty = false;
        }
        return extractedItem;
    }

    public override ItemView Remove()
    {
        ItemView result = equipedItem;
        equipedItem.transform.parent = transform.parent.parent;
        equipedItem.transform.SetAsLastSibling();
        //Debug.Log(equipedItem.name + " removed from" + gameObject.name);
        equipedItem = null;
        IsEmpty = true;
        //Debug.Log("Result: " + result.name);
        return result;
    }

    public override void Replace(ISlot replaceTarget)
    {
        //throw new System.NotImplementedException();
    }
}
