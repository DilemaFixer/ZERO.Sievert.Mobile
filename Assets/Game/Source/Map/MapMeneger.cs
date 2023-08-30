using System;
using System.Collections.Generic;
using Game.Source;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class MapMeneger : MonoBehaviour
    {
        [SerializeField] private List<ValueForCerealizedDictionary<int, MapSettings>> _valueForCerealizedDictionarie;
        [field: SerializeField] public Transform PerentForTerrian { get; private set; }
        [field: SerializeField] public Transform PerentForForest { get; private set; }
        [field: SerializeField] public Transform PerentForBildings { get; private set; }
        [field: SerializeField] public Transform PerentForRock { get; private set; }

        [SerializeField , InterfaceType(typeof(IPlayerCamera))]
        private Object _camera;

        private IPlayerCamera _playerCamera => _camera as IPlayerCamera; 
        
        private MapFactory _mapFactory;
        private Dictionary<int, MapSettings> _mapsSettings;
        public Map CurrentMap { get; private set; }

        private void Awake()
        {
            _mapsSettings = SerializableDictionary<int, MapSettings>.ConvertToDictionary(_valueForCerealizedDictionarie);
            _mapFactory = new MapFactory();
        }

        public void SpawnMap(int MapIndex)
        {
            Debug.Log(_mapsSettings);
            if (!_mapsSettings.ContainsKey(MapIndex))
            {
                throw new ArgumentException("there is no map with this index");
            }

            MapSettings mapSettings = _mapsSettings[MapIndex];
            mapSettings.SetPerent(PerentForTerrian, PerentForForest, PerentForBildings, PerentForRock);
            CurrentMap = _mapFactory.GenerateMap(mapSettings);
            _playerCamera.SetBounds(CurrentMap.Land[CurrentMap.Land.GetLength(0) -1 ,CurrentMap.Land.GetLength(1) -1].transform.position,
                CurrentMap.Land[0,0].transform.position);
        }
        
        public void DestroyMap()
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