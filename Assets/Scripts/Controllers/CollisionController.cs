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
                case TankComponent tankViewController:
                    break;
                case BaseEnemyComponent baseEnemyComponent:
                    EnemyCollision(baseEnemyComponent, other);
                    break;
                case ObstacleComponent obstacleComponent:
                    break;
            }
        }

        private static void EnemyCollision(BaseEnemyComponent enemyComponent, Collider2D collider)
        {
            var tank = collider.GetComponent<TankComponent>();
            if (tank != null)
            {
                if (!tank.Invincible)
                {
                    var isLive = _gameController.DamageController.DoDamage(tank, enemyComponent.Damage);
                    if (!isLive)
                    {
                        _gameController.RestartGame();
                    }
                    else
                    {
                        tank.StartInvincible();
                    }
                }
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