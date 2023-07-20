using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
   

    public void AddItem(IItem item, int pos);
    public IItem GetItem(int pos);
    public IItem RemoveItem(int pos);
    public int GetSize();

    
   
}
