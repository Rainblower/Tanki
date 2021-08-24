using Core;
using UnityEngine;
using Views.Weapons.Projectiles;

namespace Views.Weapons
{
    public class DefaultWeaponComponent: ProjectileWeapon
    {
        public override void Attack()
        {
            if (!CanAttack) return;
            
            var a = GameObject.Find("ObjectsPooler").GetComponent<ObjectsPooler>().GetFromPool<BaseProjectile>(PoolingItem);
            a.transform.position = ProjectileSpawnTransofm.position;
            a.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            a.Active();
            StartCountdown();
        }
    }
}