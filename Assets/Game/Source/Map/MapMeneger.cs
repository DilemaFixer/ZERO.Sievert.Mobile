using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MapMeneger : MonoBehaviour
    {
        [SerializeField] private List<ValueForCerealizedDictionary<int, MapSettings>> _valueForCerealizedDictionarie;
        [SerializeField] private MapFactory mapFactory;

        private Dictionary<int, MapSettings> _mapsSettings;
        public Map CurrentMap { get; private set; }

        private void Start()
        {
            _mapsSettings = SerializableDictionary<int, MapSettings>.ConvertToDictionary(_valueForCerealizedDictionarie);
        }

        public void SpawnMap(int MapIndex)
        {
            if (!_mapsSettings.ContainsKey(MapIndex))
            {
                throw new ArgumentException("there is no map with this index");
            }

            if (CurrentMap != null)
            {
                DestroyMap();
            }

            CurrentMap = mapFactory.GenerateMap(_mapsSettings[MapIndex] );
        }
        
        private void DestroyMap()
        {
            for (int i = 0; i < CurrentMap.Land.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentMap.Land.GetLength(1); j++)
                {
                    Destroy(CurrentMap.Land[i,j].gameObject);
                }
            }

            for (int i = 0; i < CurrentMap.DecorativeObjects.Count; i++)
            {
                Destroy(CurrentMap.DecorativeObjects[i]);
            }
            
            for (int i = 0; i < CurrentMap.Buildings.Count; i++)
            {
               Destroy(CurrentMap.Buildings[i]);
            }
        }
    }
}