using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISlot : MonoBehaviour
{
    [field: SerializeField] public bool IsEmpty { get; protected set; } = true;
    [field:SerializeField]public ItemView equipedItem { get; protected set; }
    public abstract void Put(ItemView item);
    public abstract ItemView Remove();
    public abstract void Replace(ISlot replaceTarget);
}
