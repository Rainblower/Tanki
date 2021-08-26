using Core;
using Views.Weapons.Projectiles;

namespace Views.Weapons
{
    public class InstaKillEnemyComponent: ProjectileWeapon
    {
        public override void Attack()
        {
            if (!CanAttack) return;
            
            var projectileFirst = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            
            projectileFirst.transform.position = ProjectileSpawnTransofm.position;
            projectileFirst.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileFirst.Active(Damage);
            
            StartCountdown();
        }
    }
}