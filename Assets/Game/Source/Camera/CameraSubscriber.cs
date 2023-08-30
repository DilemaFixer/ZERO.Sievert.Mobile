using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Source
{
    public class CameraSubscriber : MonoBehaviour , IPlayerCamera
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _sliping;
        [SerializeField] private Vector2 _edgeDownDistance;
        [SerializeField] private Vector2 _edgeTopDistance;
        
        private Transform _target;
        private Vector2 _maxBounds;
        private Vector2 _minBounds;

        public void SetBounds(Vector2 maxBounds, Vector2 minBounds)
        {
            _maxBounds = maxBounds + _edgeTopDistance;
            _minBounds = minBounds + _edgeDownDistance;
        }

        public void SetTarget(Transform target)
        {
            transform.SetPositionAndRotation(transform.position , quaternion.identity);
            _target = target;
        }

        public void FixedUpdate()
        {
            if (null == _target)
            {
                return;
            }
            
            Vector3 desiredPosition = _target.position + _offset;
            if (desiredPosition.x <= _minBounds.x )
            {
                desiredPosition.x = -1.336023f;
            }

            if (desiredPosition.x >= _maxBounds.x)
            {
                desiredPosition.x = 137.0083f;
            }
            
            if (desiredPosition.y <= _minBounds.y )
            {
                desiredPosition.y = 11.18612f;
            }

            if (desiredPosition.y >= _maxBounds.y)
            {
                desiredPosition.y = 194.7643f;
            }
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _sliping);
            
            transform.position = smoothedPosition;
        }
    }
}