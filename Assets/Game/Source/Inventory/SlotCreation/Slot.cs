using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : ISlot
{
    public override void Put(ItemView item)
    {
        
        equipedItem = item;
       
        equipedItem.transform.position = transform.position;
        IsEmpty = false;
        
       
        equipedItem.transform.parent = transform;
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
