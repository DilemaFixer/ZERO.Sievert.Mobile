using UnityEngine.UI;
using UnityEngine;


public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _count;
    [SerializeField] private Text _name;
    public IItem _item { get; private set; }

  
    public void Init(IItem item)
    {
        
        if (_item != null) return;
        if (item == null) return;
        _item = item;
        item.OnChange += UpdateChanges;
        UpdateChanges();
    }
    public void UpdateChanges()
    {

        if(_item.Amount <= 0)
        {
            Destroy(gameObject);
            return;
        }
        _image.sprite = _item.Data._image;
        _count.text = _item.Amount.ToString();
        _name.text = _item.Data.name;
    }
}
