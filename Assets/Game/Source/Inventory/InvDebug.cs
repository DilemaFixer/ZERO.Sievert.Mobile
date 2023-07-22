using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvDebug : MonoBehaviour
{
    [SerializeField]private ISlot slot;
    [SerializeField] private IItem item;
    public bool Put;
    private void Update()
    {
        if (Put)
        {
            Put = false;
            //slot.Put(item);
        }
    }
}
