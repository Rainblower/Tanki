using Controllers;
using Core;
using UnityEngine;
using Views.Tank;

namespace Views.Weapons.Projectiles
{
    public abstract class BaseProjectile: MonoBehaviour, ICollisionComponent
    {
        public PoolingItemType Type;
        
        private ProjectileSettings _projectileSettings;
        private bool _active;
        
        public void Init(ProjectileSettings projectileSettings)
        {
            _projectileSettings = projectileSettings;
        }
        
        public void Active()
        {
            _active = true;
        }

        public void Disable()
        {
            _active = false;
        }

        public void Update()
        {
            if (_active)
            {
                transform.position += Time.deltaTime * _projectileSettings.Direction * _projectileSettings.Speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionController.DetectCollision(this, other.collider);
        }
    }

    public struct ProjectileSettings
    {
        public Vector3 Direction;
        public float Speed;
    }
}