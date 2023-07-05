using UnityEngine.UI;
using System;
using UnityEngine;

[RequireComponent(typeof(IItem))]
[RequireComponent(typeof(ItemMovement))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    [SerializeField] private Text _count;

    private IItem item;
    public event Action OnChange;
    private void Start()
    {
        item = GetComponent<IItem>();        
        OnChange += ItemUpdate;
        item.OnChange += OnChange;
        ItemUpdate();
        
    }
    private void ItemUpdate()
    {
        _name.text = item.Data.name;
        _count.text = item.Amount.ToString();
        _image.sprite = item.Data._image;
    }
}
