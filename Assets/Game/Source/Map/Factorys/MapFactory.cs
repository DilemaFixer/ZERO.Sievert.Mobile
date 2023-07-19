using System;
using Game;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    [SerializeField] private TerrainFactory _terrainFactory;
    [SerializeField] private BuildingsFactory _buildingsFactory;
    [SerializeField] private ForestFactory _forestFactory;
    [SerializeField] private RocksFactory _rocksFactory;
    
    private Block[,] _terrainMap;
    private MapSettings _currentMapSettings;

    public Map GenerateMap(MapSettings MapConfiguration )
    {
        _currentMapSettings = MapConfiguration;
        
        Map map = new Map();

        var terrain = _terrainFactory.GenerateTerrain(MapConfiguration);
             map.SetLand(terrain);
             _terrainMap = terrain;
             map.SetBuildings(_buildingsFactory.GenerateBildings(MapConfiguration, _terrainMap));
            map.SetDecorativeObjects(_forestFactory.GenerateForest(MapConfiguration , _terrainMap));
            _rocksFactory.SpawnRocksAroundMap(_currentMapSettings , _terrainMap);
            
        return map;
    }
    
   
    
   

    
}
