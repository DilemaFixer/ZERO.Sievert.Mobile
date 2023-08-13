using Game;

public class MapFactory 
{
     private TerrainFactory _terrainFactory;
     private BuildingsFactory _buildingsFactory;
     private ForestFactory _forestFactory;
     private RocksFactory _rocksFactory;
    
    private Block[,] _terrainMap;
    private MapSettings _currentMapSettings;

    public MapFactory()
    {
        _terrainFactory = new TerrainFactory();
        _buildingsFactory = new BuildingsFactory();
        _forestFactory = new ForestFactory();
        _rocksFactory = new RocksFactory();
    }
    
    public Map GenerateMap(MapSettings MapSettings)
    {
        _currentMapSettings = MapSettings;
        
        Map map = new Map();

        var terrain = _terrainFactory.GenerateTerrain(_currentMapSettings);
             map.SetLand(terrain);
             _terrainMap = terrain;
             map.SetBuildings(_buildingsFactory.GenerateBildings(_currentMapSettings, _terrainMap));
            map.SetDecorativeObjects(_forestFactory.GenerateForest(_currentMapSettings, _terrainMap));
            _rocksFactory.SpawnRocksAroundMap(_currentMapSettings, _terrainMap);
            
        return map;
    }
    
   
    
   

    
}
