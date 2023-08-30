using System.Collections.Generic;
using System.Linq;
using Game.Source;
using Game.Source.Enemy;
using UnityEngine;

namespace Game
{
    public class TerrainFactory 
    {
        private List<Block> _grass;
        private List<Block> _ground;
        
        private MapSettings _currentMapSettings;
        private Vector3 _currentSpawnPosition;
        private Transform _perent;
        
        private int _currentWidth;
        
        public Block[,] GenerateTerrain(MapSettings CurrentMapSettings)
        {
            _currentMapSettings = CurrentMapSettings;
            
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
                        currentBlock = _currentMapSettings.Lake;
                    else if (noiseValue < 0.66f)
                        currentBlock = IEnumerableHealper.GetRandomObjFromList(_currentMapSettings.Grass);
                    else
                        currentBlock = IEnumerableHealper.GetRandomObjFromList(_currentMapSettings.Ground);

                    blocksMap[x, y] = Spawn(currentBlock);
                    StepToNextSpawnPosition();
                }
            }

            return blocksMap;
        }

        private T Spawn<T>(T Prefabs) where T : Object
        {
            T  result = GameObject.Instantiate(Prefabs, _currentSpawnPosition, Quaternion.identity, _currentMapSettings.PerentForTerrian);
            return result;
        }
    
        private void StepToNextSpawnPosition()
        {
            _currentWidth++;
            if(_currentWidth == _currentMapSettings.Width)
            {
                _currentSpawnPosition.x = _currentMapSettings.SpawnPoint.position.x;
                _currentSpawnPosition.y += _currentMapSettings.SpawnOffsetFromY;
                _currentWidth = 0;
            }
            else
            {
                _currentSpawnPosition.x += _currentMapSettings.SpawnOffsetFromX;
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