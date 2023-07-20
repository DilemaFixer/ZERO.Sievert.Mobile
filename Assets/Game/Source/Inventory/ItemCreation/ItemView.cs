using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(IItem))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _count;
    [SerializeField] private Text _name;

    private void Start()
    {
        UpdateChanges();
        GetComponent<IItem>().OnChange += UpdateChanges;
    }
    public void UpdateChanges()
    {
        IItem item = GetComponent<IItem>();
        _image.sprite = item.Data._image;
        _count.text = item.Amount.ToString();
        _name.text = item.Data.name;
    }
}
