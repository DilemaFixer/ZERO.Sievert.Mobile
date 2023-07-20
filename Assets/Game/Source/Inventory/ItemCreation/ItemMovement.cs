using UnityEngine.EventSystems;
using UnityEngine;

public interface ItemMovement
{
    public void BeginDrag(PointerEventData eventData);
    public void OnDrag();
    public void EndDrag(PointerEventData eventData);
}
