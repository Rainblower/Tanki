using System.Threading.Tasks;
using Core;
using Views.Weapons.Projectiles;

namespace Views.Weapons
{
    public class TripleWeaponComponent: ProjectileWeapon
    {
        public override async void Attack()
        {
            if (!CanAttack) return;
            
            StartCountdown();

            var projectileFirst = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            projectileFirst.transform.position = ProjectileSpawnTransofm.position;
            projectileFirst.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileFirst.Active(Damage/3);

            await Task.Delay(100);

            var projectileSecond = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            projectileSecond.transform.position = ProjectileSpawnTransofm.position;
            projectileSecond.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileSecond.Active(Damage/3);
            await Task.Delay(100);
            
            var projectileThird = BaseController.SystemController.GameController.ObjectsPooler.GetFromPool<BaseProjectile>(PoolingItem);
            projectileThird.transform.position = ProjectileSpawnTransofm.position;
            projectileThird.Init(new ProjectileSettings{Direction = transform.up, Speed = Speed});
            projectileThird.Active(Damage/3);
            await Task.Delay(100);
        }
    }
}