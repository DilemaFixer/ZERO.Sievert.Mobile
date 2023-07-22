using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField] private ISlot emptySlotTemplate;
    [SerializeField] private ItemView emptyItemTemplate;
    [SerializeField] private GameObject slotContainer;
    private List<ISlot> slots = new();
    private IInventory inventory;
    private void Start()
    {
        inventory = GetComponent<IInventory>();
        DrawUI();
    }
    public void DrawUI()
    {
        DrawSlots();
        DrawItems();
    }
    private void DrawSlots()
    {
        for(int i = 0; i < inventory.GetSize(); i++)
        {
            ISlot slot = Instantiate(emptySlotTemplate, slotContainer.transform);
            slots.Add(slot);
        }
    }
    private void DrawItems()
    {
        for(int i = 0; i < inventory.GetSize(); i++)
        {
            IItem item = inventory.GetItem(i);
            if(item != null)
            {
                ItemView itemView = Instantiate(emptyItemTemplate, slots[i].gameObject.transform);
                itemView.Init(item);
                slots[i].Put(itemView);
            }
        }
    }
    
}
