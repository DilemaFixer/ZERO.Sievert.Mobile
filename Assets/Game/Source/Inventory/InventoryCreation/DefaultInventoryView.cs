using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInventoryView : MonoBehaviour, IInventoryView,IPointerDownHandler
{
    [SerializeField] private ISlot emptySlotTemplate;
    
    [SerializeField] private ItemPanel panel;
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
                itemView.gameObject.GetComponent<DefaultItemMovement>().OnPanelActivate += (IItem item) =>
                {
                    panel.gameObject.SetActive(true);
                    panel.InitializePanel(item);
                };
                itemView.gameObject.GetComponent<DefaultItemMovement>().OnPanelDeactivate += panel.DeactivatePanel;
                itemView.Init(item);
                slots[i].Put(itemView);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        List<RaycastResult> result = new();
        EventSystem.current.RaycastAll(eventData, result);
        foreach (RaycastResult res in result)
        {
            if (res.gameObject.GetComponent<ItemView>())
            {
                return;
            }

        }
        panel.DeactivatePanel();
    }
}
