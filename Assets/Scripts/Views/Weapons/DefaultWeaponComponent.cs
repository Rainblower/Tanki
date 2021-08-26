using Core;
using Views.Weapons.Projectiles;

namespace Views.Weapons
{
    public class DefaultWeaponComponent: ProjectileWeapon
    {
        public override void Attack()
        {
            if (!CanAttack) return;

            var projectile = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            projectile.transform.position = ProjectileSpawnTransofm.position;
            projectile.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectile.Active(Damage);
            StartCountdown();
        }
    }
}