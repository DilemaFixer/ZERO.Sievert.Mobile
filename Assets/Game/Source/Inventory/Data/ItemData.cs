using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [field: SerializeField] public Sprite _image { get; private set; }
    [field: SerializeField] public int maxStack { get; private set; }
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public float weight{ get; private set; }
    [field: SerializeField] public int Id { get; private set; }
}
