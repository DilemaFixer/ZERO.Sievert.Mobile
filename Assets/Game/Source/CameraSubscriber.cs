using UnityEngine;

namespace Game.Source
{
    public class CameraSubscriber : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _sliping;
        
        
       public void FixedUpdate()
        {
            Vector3 desiredPosition = _target.position + _offset;
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _sliping);
            
            transform.position = smoothedPosition;
        }
    }
}