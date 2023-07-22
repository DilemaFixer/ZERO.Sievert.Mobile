using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInventory :MonoBehaviour, IInventory
{
    [SerializeField] private List<IItem> items = new(20);
    [SerializeField] private int _size = 20;
    [SerializeField] private List<int> idOfitems;
    [SerializeField] private List<int> amountOfItems;
    [SerializeField] private AllItemsData allData;
    

    //public DefaultInventory(Json data)

    private void Awake()
    {
        //Debug.Log("Items Count: " + items.Count);
        items = new List<IItem>(_size);
        
        DeserializeItems();
        Debug.Log("Items Count: " + items.Count);
        //items = new(_size);
    }
    private void DeserializeItems()
    {
        
        for (int i = 0; i < _size; i++)
        {
            if (i >= idOfitems.Count || i >= amountOfItems.Count) items.Add(null);
            else if (idOfitems[i] > 0 && amountOfItems[i] > 0)
            {
                IItem item = new Item(allData.FindItemById(idOfitems[i]), amountOfItems[i]);
                items.Add(item);
            }
            else items.Add(null);

           
        }
    }
    public void AddItem(IItem item, int pos)
    {
        if(pos < items.Count && pos < _size)
        {
            items[pos] = item;
        }
    }

    public IItem GetItem(int pos)
    {
        if(pos < items.Count && pos < _size)
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
        if(pos < items.Count && pos < _size)
        {
            IItem item = items[pos];
            items[pos] = null;
            return item;
        }
        return null;
    }
}
