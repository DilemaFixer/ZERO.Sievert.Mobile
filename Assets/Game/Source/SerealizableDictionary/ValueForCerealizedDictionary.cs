using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class ValueForCerealizedDictionary<T1, T2> 
    {
        [SerializeField] private T1 _key;
        [SerializeField] private T2 _value;
        public T2 Value { get { return _value; } }
        public T1 Key { get { return _key; } }
    }
}