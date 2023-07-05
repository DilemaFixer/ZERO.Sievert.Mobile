using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItem:MonoBehaviour
{
    [field: SerializeField]public int Amount { get; private set; }
    [SerializeField]public ItemData Data { get; private set; }
    public abstract void Add(IItem item);
    public abstract IItem DivideItem(int ratio1, int ratio2);
}
