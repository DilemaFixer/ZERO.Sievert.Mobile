using System;
using UnityEngine;

namespace Game.Entities.Player
{
    public class PlayermMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private int smoothnessFactor;
        [SerializeField] private float _currentSpeed;
        
        private VariableJoystick _variableJoystick;
        
        private bool IsRun;
        
        private void Start()
        {
            _currentSpeed = _minSpeed;
        }

        public void SetJoystic(VariableJoystick variableJoystick)
        {
            _variableJoystick = variableJoystick;
        }
        
        private void FixedUpdate()
        {
            if (IsRun)
            {
                if (_currentSpeed < _maxSpeed)
                {
                    _currentSpeed += _maxSpeed / smoothnessFactor;
                }
            }
            
            float moveInputX = _variableJoystick.Horizontal;
            float moveInputY = _variableJoystick.Vertical;
            
            Vector3 movement = new Vector3(moveInputX, moveInputY, 0f);
            transform.position += movement * _currentSpeed * Time.deltaTime;

            if (moveInputX == 0f || moveInputY == 0f)
            {
                IsRun = false;
                _currentSpeed = _minSpeed;
                return;
            }

            IsRun = true;
        }
    }
}