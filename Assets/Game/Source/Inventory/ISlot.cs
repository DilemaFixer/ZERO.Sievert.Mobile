using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISlot
{
    public bool IsEmpty { get; private set; }
    //Item
    public abstract void Put();
    public abstract void Remove();
    public abstract void Replace(ISlot replaceTarget);
}
