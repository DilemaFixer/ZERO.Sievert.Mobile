using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPanel : MonoBehaviour
{
    [SerializeField]private GameObject itemPanelPrefab;
    [SerializeField] private List<Button> buttons = new();
    private void Start()
    {
        
    }
    public void InitializePanel(IItem item)
    {
        itemPanelPrefab.SetActive(true);
        itemPanelPrefab.transform.position = Input.mousePosition;
        foreach (Button button in buttons) button.gameObject.SetActive(true);

        if (item.Data is IEquipable)
        {
            Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
            e.AddListener((item.Data as IEquipable).Equip);
            buttons[0].onClick = e;
            buttons[0].GetComponentInChildren<Text>().text = "Экипировать";
        }
        else if(item.Data is IUsable)
        {
            Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
            e.AddListener((item.Data as IUsable).Use);
            buttons[0].onClick = e;
            buttons[0].GetComponentInChildren<Text>().text = "Использовать";
        }
        else
        {
            buttons[0].gameObject.SetActive(false);
        }
        buttons[1].GetComponentInChildren<Text>().text = "Разделить";
        buttons[2].GetComponentInChildren<Text>().text = "Выбросить";
    }
    public void ActivatePanel()
    {
        itemPanelPrefab.SetActive(true);
    }
    public void DeactivatePanel()
    {
        itemPanelPrefab.SetActive(false);
    }

    
}
