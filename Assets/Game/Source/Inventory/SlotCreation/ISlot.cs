using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISlot : MonoBehaviour
{
    public bool IsEmpty { get; protected set; } = true;
    public IItem equipedItem { get; protected set; }
    public abstract void Put(IItem item);
    public abstract IItem Remove();
    public abstract void Replace(ISlot replaceTarget);
}
