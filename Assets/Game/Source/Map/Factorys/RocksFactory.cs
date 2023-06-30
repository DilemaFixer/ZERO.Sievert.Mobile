using UnityEngine;

namespace Game
{
    public class RocksFactory : MonoBehaviour
    {
         
        [SerializeField] private Transform _perent;
        [SerializeField] private float _offsetX;
        [SerializeField] private float _offsetY;
        
        private GameObject _rocksPrefab;
        private Vector3 _currentSpawnPoint;
        private MapSettings _settings;
        private Block[,] _terrain;
        
        public void SpawnRocksAroundMap(MapSettings Settings , Block[,] Terrain)
        {
            _settings = Settings;
            _terrain = Terrain;
            _rocksPrefab = Settings.RocksPrefab;
            SpawnOneSide(0, 0, _settings.Width ,StepType.Down, StepType.Right);
            SpawnOneSide(Terrain.GetLength(0) -1, 0, _settings.Height,StepType.Left, StepType.Down);
            
            SpawnOneSide(Terrain.GetLength(0) -1 , Terrain.GetLength(1) - 1 , 
                _settings.Width ,StepType.Up , StepType.Left);
            
            SpawnOneSide(0, Terrain.GetLength(1) - 1 , _settings.Height ,
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
            var result = Instantiate(_rocksPrefab, _currentSpawnPoint,
                Quaternion.identity, _perent);
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

    public enum TypesSidesSquare
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum StepType
    {
        Up,
        Down,
        Left,
        Right
    }
}