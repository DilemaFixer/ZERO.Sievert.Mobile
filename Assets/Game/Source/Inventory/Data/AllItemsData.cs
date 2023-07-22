using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items Data", menuName = "ItemsData/ItemsStorage")]
public class AllItemsData : ScriptableObject
{
    [field: SerializeField] private List<ItemData> _allItemsData;

    public ItemData FindItemById(int id)
    {
        foreach(ItemData item in _allItemsData)
        {
            if(item.Id == id)
            {
                return item;
            }
        }
        Debug.Log("Item by id: " + id + " has not finded");
        return null;
    }
}
