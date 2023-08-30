using System;
using Game.Entities.Player;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Source
{
    public class LevelAssembler : MonoBehaviour
    {
        [SerializeField] private MapMeneger _mapMeneger;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField , InterfaceType(typeof(IPlayerCamera))]
        private Object _camera;

        private Player _currentPlayer;
        
        private IPlayerCamera _playerCamera => _camera as IPlayerCamera;
        private void Start()
        {
            _mapMeneger.SpawnMap(SceneData.MapIndex);
            _currentPlayer = Instantiate(_playerPrefab, _mapMeneger.CurrentMap.GetUnlockedBlock().transform.position, quaternion.identity);
            _currentPlayer.SetJoystic(_variableJoystick);
           _playerCamera.SetTarget(_currentPlayer.transform);
        }

        private void OnDisable()
        {
            _mapMeneger.DestroyMap();
            Destroy(_currentPlayer);
        }
    }
}