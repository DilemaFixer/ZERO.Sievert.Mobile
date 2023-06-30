using UnityEngine;

namespace Game.Source.Player
{
    public class PlayermMovement : MonoBehaviour
    {
        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField] private float _speed;

        public float speed = 5f;

        private void FixedUpdate()
        {
            float moveInputX = _variableJoystick.Horizontal;
            float moveInputY = _variableJoystick.Vertical;

            Vector3 movement = new Vector3(moveInputX, moveInputY, 0f);
            transform.position += movement * _speed * Time.deltaTime;
        }
    }
}