using System;
using UnityEngine;
using Views.Tank;

namespace Views.Enemies
{
    public class BaseEnemyComponent: Entity, ICollisionComponent
    {
        [SerializeField] private float _health = default;
        [SerializeField] private float _armor = default;
        [SerializeField] private float _damage = default;
        [SerializeField] private float _speed = default;

        public float Damage => _damage;
        public float Speed => _speed;

        private Transform _target;

        private void Start()
        {
            Health = _health;
            Armor = _armor;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                RotateToTarget();
                MoveToTarget();
            }
        }

        private void RotateToTarget()
        {
            Vector3 dir = _target.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void MoveToTarget()
        {
            transform.position += transform.right * Time.deltaTime * _speed;
        }
    }
}