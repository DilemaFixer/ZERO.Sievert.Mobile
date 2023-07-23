using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DefaultItemMovement : MonoBehaviour, ItemMovement, IPointerDownHandler,IPointerUpHandler
{
    private ItemView _item;
    private ISlot _previousSlot;
    private int _previousSibling;
    private bool isMove = false;
    
    private void Start()
    {
        _item = GetComponent<ItemView>();
    }
    public void Update()
    {
        if (isMove)
        {
            OnDrag();

        }
    }
    public void BeginDrag(PointerEventData eventData)
    {

        _previousSlot = FindSlot(eventData);        
        _previousSlot.Remove();
        _previousSibling = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

    public void OnDrag()
    {

        transform.position = Input.mousePosition;

    }

    public void EndDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(_previousSibling);
        ISlot slot = FindSlot(eventData);
        if (slot == null)
        {
            _previousSlot.Put(_item);
            return;
        }
        ItemView extracted = slot.Put(_item);
        if (extracted != null) _previousSlot.Put(extracted);
    }


    private ISlot FindSlot(PointerEventData eventData)
    {
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);
        for (int i = 0; i < result.Count; i++)
        {
            if (result[i].gameObject.GetComponent<ISlot>() != null)
            {
                return result[i].gameObject.GetComponent<ISlot>();
            }

        }
        return null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(StartPress(1f));
        BeginDrag(eventData);
        /*if (isMove) EndDrag(eventData);
        else BeginDrag(eventData);
        isMove = !isMove;*/
    }

    public void OnPointerUp(PointerEventData eventData)
    {
          isMove = false;
          EndDrag(eventData);
          StopAllCoroutines();
            
        
    }
    private IEnumerator StartPress(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        isMove = true;
        
        
        
    }
}
