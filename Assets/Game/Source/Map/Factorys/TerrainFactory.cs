using System.Collections.Generic;
using System.Linq;
using Game.Source;
using UnityEngine;

namespace Game
{
    public class TerrainFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnOffsetFromX;
        [SerializeField] private float _spawnOffsetFromY;

         
        [SerializeField] private Transform _perent;
        
        private Vector3 _currentSpawnPosition;
        private int _currentWidth;
        private MapSettings _currentMapSettings;
        private List<Block> _grass;
        private List<Block> _ground;
        private Block _lake;
        
        public Block[,] GenerateTerrain(MapSettings CurrentMapSettings)
        {
            _currentMapSettings = CurrentMapSettings;
            _grass = CurrentMapSettings.Grass;
            _ground = CurrentMapSettings.Ground;
            _lake = CurrentMapSettings.Lake;
            
            Block[,] blocksMap = new Block[_currentMapSettings.Height ,_currentMapSettings.Width];
            float[,] noise = MakeNoiseMap(_currentMapSettings);
            _currentSpawnPosition = _currentMapSettings.SpawnPoint.position;
            _currentWidth = 0;

            for (int x = 0; x < _currentMapSettings.Height; x++)
            {
                for (int y = 0; y < _currentMapSettings.Width; y++)
                {
                    float noiseValue = noise[x, y];
                    Block currentBlock;
                
                    if (noiseValue < 0.10f)
                        currentBlock = _lake;
                    else if (noiseValue < 0.66f)
                        currentBlock = IEnumerableHealper.GetRandomObjFromList(_grass);
                    else
                        currentBlock = IEnumerableHealper.GetRandomObjFromList(_ground);

                    blocksMap[x, y] = Spawn(currentBlock);
                    StepToNextSpawnPosition(_currentMapSettings);
                }
            }

            return blocksMap;
        }

        private T Spawn<T>(T Prefabs) where T : Object
        {
            T  result = Instantiate(Prefabs, _currentSpawnPosition, Quaternion.identity, _perent);
            return result;
        }
    
        private void StepToNextSpawnPosition(MapSettings _currentMapSettings)
        {
            _currentWidth++;
            if(_currentWidth == _currentMapSettings.Width)
            {
                _currentSpawnPosition.x = _currentMapSettings.SpawnPoint.position.x;
                _currentSpawnPosition.y += _spawnOffsetFromY;
                _currentWidth = 0;
            }
            else
            {
                _currentSpawnPosition.x += _spawnOffsetFromX;
            }
        }
        private float[,] MakeNoiseMap(MapSettings _currentMapSettings)
        {
            float[,] noiseMap = new float[_currentMapSettings.Height , _currentMapSettings.Width];
            float offsetX = Random.Range(0f, 10000f); 
            float offsetY = Random.Range(0f, 10000f);
        
            for (int x = 0; x < _currentMapSettings.Height; x++)
            {
                for (int y = 0; y < _currentMapSettings.Width; y++)
                {
                    float sampleX = (float)(x + offsetX) / _currentMapSettings.Width * _currentMapSettings.Scale;
                    float sampleY = (float)(y + offsetY) / _currentMapSettings.Height * _currentMapSettings.Scale;
                    noiseMap[x, y] = Mathf.PerlinNoise(sampleX , sampleY);
                }
            }
            return noiseMap;
        }
   
    }
}