using UnityEngine;

namespace Game
{
    public class RocksFactory 
    {
        private GameObject _rocksPrefab;
        private Vector3 _currentSpawnPoint;
        private MapSettings _settings;
        private Block[,] _terrain;
        
        private float _offsetX = 0.99f;
        private float _offsetY = 1f;

        public void SpawnRocksAroundMap(MapSettings Settings , Block[,] Terrain)
        {
            _settings = Settings;
            _terrain = Terrain;
            _rocksPrefab = Settings.RocksPrefab;

            SpawnOneSide(0, 0, _settings.Width ,StepType.Down, StepType.Right);
            SpawnOneSide(_terrain.GetLength(0) -1, 0, _settings.Height,StepType.Left, StepType.Down);
            
            SpawnOneSide(_terrain.GetLength(0) -1 , _terrain.GetLength(1) - 1 , 
                _settings.Width ,StepType.Up , StepType.Left);
            
            SpawnOneSide(0, _terrain.GetLength(1) - 1 , _settings.Height ,
                StepType.Right , StepType.Up);
        }

        private void SpawnOneSide(int X , int Y , int CountOfSteps ,StepType FirstStep , StepType VectorOfSpwn)
        {
            _currentSpawnPoint = _terrain[X, Y].transform.position;
            StepToNextPoint(FirstStep);
            
            for (int i = 0; i < CountOfSteps + 1; i++)
            {
                SpawnWithStep(VectorOfSpwn);
            }
        }
        private GameObject SpawnWithStep(StepType Step)
        {
            var result = GameObject.Instantiate(_rocksPrefab, _currentSpawnPoint,
                Quaternion.identity, _settings.PerentForRock);
            StepToNextPoint(Step);
             return result;
        }

        private void StepToNextPoint(StepType Step)
        {
            switch (Step)
            {
                case StepType.Up:
                    _currentSpawnPoint.y += _offsetY;
                    break;
                case StepType.Down:
                    _currentSpawnPoint.y -= _offsetY;
                    break;
                case StepType.Right:
                    _currentSpawnPoint.x += _offsetX;
                    break;
                case StepType.Left:
                    _currentSpawnPoint.x -= _offsetX;
                    break;
            }
        }
    }
    
    public enum StepType
    {
        Up,
        Down,
        Left,
        Right
    }
}