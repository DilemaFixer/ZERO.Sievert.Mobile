using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInventory :MonoBehaviour, IInventory
{
    [SerializeField] private List<IItem> items;
    [SerializeField] private int _size = 20;

    private void Start()
    {
        //items = new(_size);
    }
    public void AddItem(IItem item, int pos)
    {
        if(pos < _size)
        {
            items[pos] = item;
        }
    }

    public IItem GetItem(int pos)
    {
        if(pos < _size)
        {
            return items[pos];
        }
        else
        {
            return null;
        }
    }

    public int GetSize()
    {
        return _size;
    }

    public IItem RemoveItem(int pos)
    {
        if(pos < _size)
        {
            IItem item = items[pos];
            items[pos] = null;
            return item;
        }
        return null;
    }
}
