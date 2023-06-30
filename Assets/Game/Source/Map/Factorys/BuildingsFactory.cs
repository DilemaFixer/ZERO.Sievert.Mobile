using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BuildingsFactory : MonoBehaviour
    {
        [SerializeField] private Transform _perent;
        
        private MapSettings _currentMapSettings;
        private Block[,] _terrainMap;
        private SettingsForBildingGenerator _settingsForBildingGenerator;
     public List<GameObject> GenerateBildings(MapSettings CurrentMapSettings , Block[,] TerrainMap)
     {
         _currentMapSettings = CurrentMapSettings;
         _terrainMap = TerrainMap;
         
        List<GameObject> result = new List<GameObject>();
         _settingsForBildingGenerator = _currentMapSettings.SettingsForBildingGenerator;
        
        for (int i = 0; i < _settingsForBildingGenerator.CompulsoryBuildings.Count ; i++)
        {
          var spawnBlock = SearchingFreeSpace(_settingsForBildingGenerator.CompulsoryBuildings[i].Width ,
              _settingsForBildingGenerator.CompulsoryBuildings[i].Height );
          
          result.Add(Instantiate(_settingsForBildingGenerator.CompulsoryBuildings[i].Prefab , spawnBlock.transform.position ,
              Quaternion.identity , _perent));
        }

        for (int i = 0; i < _settingsForBildingGenerator.CountOfDungee; i++)
        {
            var spawnBlock = SearchingFreeSpace(_settingsForBildingGenerator.Dunges[i].Width ,
                _settingsForBildingGenerator.Dunges[i].Height);
          
            result.Add(Instantiate(_settingsForBildingGenerator.Dunges[i].Prefab , spawnBlock.transform.position ,
                Quaternion.identity ,  _perent));
        }
        
        return result;
    }
    
     private Block SearchingFreeSpace(int width, int height)
    {
        Block[,] viewableArea = new Block[width, height];
        SpawningCoordinates spawningCoordinates;
        bool spaceFound = false;
    
        while (!spaceFound)
        {
            spawningCoordinates = FoundSpawningCoordinates(width, height);
            spaceFound = true;
        
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    var terrain = _terrainMap[spawningCoordinates.X + x, spawningCoordinates.Y + y];
                
                    if (terrain.BlockState == BlockStates.NotAvailable)
                    {
                        spaceFound = false;
                        break;
                    }
                
                    viewableArea[x, y] = terrain;
                }
            
                if (!spaceFound)
                {
                    break;
                }
            }
        }

        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                viewableArea[x, y].SetNotAvailable();
            }
        }
        return viewableArea[ height / 2 , width / 2];
    }
    
     private SpawningCoordinates FoundSpawningCoordinates(int width, int height)
    {
        int maxX = _currentMapSettings.Height - height;
        int maxY = _currentMapSettings.Width - width;

        int x = Random.Range(0, maxX + 1);
        int y = Random.Range(0, maxY + 1);

        SpawningCoordinates spawningCoordinates = new SpawningCoordinates(x, y);
        return spawningCoordinates;
    }
    }
}