using System.Collections.Generic;
using Game.Source;
using UnityEngine;

namespace Game
{
    public class ForestFactory : MonoBehaviour
    {
         
        [SerializeField] private Transform _perent;
        
        private List<GameObject> _forest;
        private MapSettings _currentMapSettings;
        private Block[,] _terrainMap;
        public GameObject Forest { get { return IEnumerableHealper.GetRandomObjFromList(_forest); } }
        
        public List<GameObject> GenerateForest(MapSettings CurrentMapSettings , Block[,] TerrainMap)
        {
            _currentMapSettings = CurrentMapSettings;
            _terrainMap = TerrainMap;
            _forest = CurrentMapSettings.Forest;
            
            List<GameObject> DecorObj = new List<GameObject>();
            for (int x = 0; x < _currentMapSettings.Height; x++)
            {
                for (int y = 0; y < _currentMapSettings.Width; y++)
                {
                    if (Random.value < _currentMapSettings.TreeDensity && _terrainMap[x,y].BlockState == BlockStates.Available)
                    {
                        Vector2 spawnPoint = _terrainMap[x, y].transform.position;
                        DecorObj.Add(Instantiate(Forest, spawnPoint, 
                            Quaternion.identity,_perent)); 
                    }
                }
            }

            return DecorObj;
        }
    }
}