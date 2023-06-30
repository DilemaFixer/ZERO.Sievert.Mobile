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
        private Map _currentMap;

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

            if (_currentMap != null)
            {
                DestroyMap();
            }

            _currentMap = mapFactory.GenerateMap(_mapsSettings[MapIndex] );
        }
        
        private void DestroyMap()
        {
            for (int i = 0; i < _currentMap.Land.GetLength(0); i++)
            {
                for (int j = 0; j < _currentMap.Land.GetLength(1); j++)
                {
                    Destroy(_currentMap.Land[i,j].gameObject);
                }
            }

            for (int i = 0; i < _currentMap.DecorativeObjects.Count; i++)
            {
                Destroy(_currentMap.DecorativeObjects[i]);
            }
            
            for (int i = 0; i < _currentMap.Buildings.Count; i++)
            {
               Destroy(_currentMap.Buildings[i]);
            }

            _currentMap = null;
        }
    }
}