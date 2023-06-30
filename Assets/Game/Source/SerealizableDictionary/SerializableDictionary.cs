using System;
using System.Collections.Generic;


namespace Game
{
    public static class SerializableDictionary <T , Y>
    {
        private static List<T> _key;
        private static List<Y> _value;

        public static Dictionary<T, Y> ConvertToDictionary(
            List<ValueForCerealizedDictionary<T, Y>> valueForDictionaries)
        {
            Dictionary<T, Y> dictionary = new Dictionary<T, Y>();
            List<T> _key = new List<T>();
            List<Y> _value = new List<Y>();
            
            for (int i = 0; i < valueForDictionaries.Count; i++)
            {
                _key.Add(valueForDictionaries[i].Key);
                _value.Add(valueForDictionaries[i].Value);
            }
            
            if (_key.Count != _value.Count)
            {
                throw new IndexOutOfRangeException("Number of values in one of the lists does not match");
            }

            dictionary = new Dictionary<T, Y>();
            for (int i = 0; i < _key.Count; i++)
            {
                dictionary.Add(_key[i] , _value[i]);
            }

            return dictionary;
        }
    }
}