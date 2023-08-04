using System.Collections.Generic;
using Game.Effects;
using Game.Entities;
using UnityEngine;

namespace Game.Weapon.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;
        [SerializeField] protected int _longFlightTime;
        [SerializeField] private int _penetrationCapacity;
        [SerializeField] private int _damage;
        [SerializeField] public LayerMask _targetLayers;

        private List<Effect<Entity>> _effects = new List<Effect<Entity>>();

        private Vector3 _direction;
        private Entity _currentEntity;
        private float _timer;
        protected virtual bool _shouldDestroyByDefault { get; } = true;

        protected virtual void Update()
        {
            if (_direction != null)
                transform.position += _direction * speed * Time.deltaTime;

            _timer += Time.deltaTime;
            if (_timer >= _longFlightTime)
            {
                DestroyBullet();
            }
        }

        public void SetVectorMove(Vector3 shootDirection)
        {
            _direction = shootDirection.normalized;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Entity>(out _currentEntity))
            {
                ApplyEffects();
                AdditionalProcessing(other);
            }

            if (_shouldDestroyByDefault)
            {
                DestroyBullet();
            }
        }

        protected virtual void AdditionalProcessing(Collider2D other) { }

        protected void ApplyEffects()
        {
            _currentEntity.ApplyDamag(_damage, _penetrationCapacity);
            for (int i = 0; i < _effects.Count; i++)
            {
                _currentEntity.ApplyEffect(_effects[i]);
            }
        }

        protected void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}