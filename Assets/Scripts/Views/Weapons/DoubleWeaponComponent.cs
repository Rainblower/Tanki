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
            
            var a = GameObject.Find("ObjectsPooler").GetComponent<ObjectsPooler>().GetFromPool<BaseProjectile>(PoolingItem);
            var b = GameObject.Find("ObjectsPooler").GetComponent<ObjectsPooler>().GetFromPool<BaseProjectile>(PoolingItem);
            a.transform.position = ProjectileSpawnTransofm.position;
            a.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            a.Active();
            
            b.transform.position = _additionalProjectileSpawnTransofrm.position;
            b.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            b.Active();
            StartCountdown();
        }
    }
}