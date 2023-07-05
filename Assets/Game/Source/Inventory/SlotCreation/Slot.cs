using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : ISlot
{
    public override void Put(IItem item)
    {
        equipedItem = item;
        equipedItem.transform.position = transform.position;
        IsEmpty = false;
        Debug.Log(item.name + " added to" + gameObject.name);
    }

    public override IItem Remove()
    {
        IItem result = equipedItem;
        Debug.Log(equipedItem.name + " removed from" + gameObject.name);
        equipedItem = null;
        IsEmpty = true;
        Debug.Log("Result: " + result.name);
        return result;
    }

    public override void Replace(ISlot replaceTarget)
    {
        //throw new System.NotImplementedException();
    }
}
