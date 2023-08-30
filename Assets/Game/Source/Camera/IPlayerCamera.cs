using UnityEngine;

namespace Game.Source
{
    public interface IPlayerCamera
    {
        public void SetBounds(Vector2 maxBounds, Vector2 minBounds);
        public void SetTarget(Transform target);
    }
}