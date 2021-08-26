using Core;
using SO;
using UnityEngine;
using Views.Enemies;
using Views.Obstacles;
using Views.Tank;
using Views.Weapons.Projectiles;

namespace Controllers
{
    public class CollisionController
    {
        private static GameController _gameController;
        public CollisionController(GameController gameController)
        {
            _gameController = gameController;
        }

        public static void DetectCollision(ICollisionComponent collisionComponent, Collider2D other)
        {
            switch (collisionComponent)
            {
                case BaseProjectile projectile:
                    ProjectileCollision(projectile,other);
                    break;
                case TankViewController tankViewController:
                    break;
                case BaseEnemyComponent baseEnemyComponent:
                    break;
                case ObstacleComponent obstacleComponent:
                    break;
            }
        }

        private static void ProjectileCollision(BaseProjectile projectile,Collider2D collider)
        {
            var enemy = collider.GetComponent<BaseEnemyComponent>();
            if (enemy != null)
            {
                var isLive = _gameController.DamageController.DoDamage(enemy, projectile.Damage);
                if (!isLive)
                {
                    _gameController.EnemyController.KillEnemy(enemy);
                }
            }
            
            projectile.Disable();
            _gameController.ObjectsPooler.ReturnToPool(projectile.Type, projectile.gameObject);
        }
    }
}