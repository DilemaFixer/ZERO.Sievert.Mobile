using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DefaultItemMovement : MonoBehaviour, ItemMovement, IPointerDownHandler
{
    private IItem _item;
    private ISlot _previousSlot;
    private int _previousSibling;
    private bool isMove = false;
    
    private void Start()
    {
        _item = GetComponent<IItem>();
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
            transform.position = _previousSlot.transform.position;
            return;
        }

        if (!slot.IsEmpty)
        {
            if (_item.Data.Id != slot.equipedItem.Data.Id)
            {
                IItem extractedItem = slot.Remove();
                _previousSlot.Put(extractedItem);
                slot.Put(_item);
            }
            else
            {
                slot.equipedItem.Add(_item);
                //if (_previousSlot.equipedItem != null)
                //{
                transform.position = _previousSlot.transform.position;
                _previousSlot.Put(_item);

                //}
                /*else
                {
                    _previousSlot.Remove();
                }*/
            }
        }
        else
        {
            slot.Put(_item);
            //_previousSlot?.Remove();
        }

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
        if (isMove) EndDrag(eventData);
        else BeginDrag(eventData);
        isMove = !isMove;
    }
}
