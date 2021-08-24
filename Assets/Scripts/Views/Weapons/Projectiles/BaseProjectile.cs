using System;
using UnityEngine;

namespace Views.Weapons.Projectiles
{
    public abstract class BaseProjectile: MonoBehaviour
    {
        public Collider2D Collider2D;

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
    }

    public struct ProjectileSettings
    {
        public Vector3 Direction;
        public float Speed;
    }
}