using Core;
using UnityEngine;
using Views.Weapons.Projectiles;

namespace Views.Weapons
{
    public class DoubleWeaponComponent: ProjectileWeapon
    {
        [SerializeField] private Transform _additionalProjectileSpawnTransofrm = default;
        
        public override void Attack()
        {
            if (!CanAttack) return;
            
            var projectileFirst = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            var projectileDouble = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            
            projectileFirst.transform.position = ProjectileSpawnTransofm.position;
            projectileFirst.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileFirst.Active();
            
            projectileDouble.transform.position = _additionalProjectileSpawnTransofrm.position;
            projectileDouble.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileDouble.Active();
            StartCountdown();
        }
    }
}