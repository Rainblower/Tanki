using System.Collections.Generic;
using SO;
using UnityEngine;
using Views.Enemies;

namespace Controllers
{
    public class EnemyController
    {
        private GameConfig _gameConfig;
        
        private TankComponent _target;
        private LevelComponent _currentLevel;

        private Transform _enemiesTransofm;
        private Transform _parent;
        
        private bool _canSpawn;
        private float _timer;

        private List<BaseEnemyComponent> _livingEnemies = new List<BaseEnemyComponent>();

        public EnemyController(Transform parent,GameConfig gameConfig)
        {
            _parent = parent;
            _gameConfig = gameConfig;
        }

        public void Start(TankComponent target, LevelComponent level)
        {
            _target = target;
            _currentLevel = level;

            if (_enemiesTransofm == null)
            {
                GameObject go = new GameObject("Enemies");
                go.transform.parent = _parent;
                _enemiesTransofm = go.transform;
            }
            
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            _canSpawn = true;
        }

        public void EndGame()
        {
            _canSpawn = false;
            
            foreach (var enemyComponent in _livingEnemies)
            {
                Object.Destroy(enemyComponent.gameObject);
            }
            
            _livingEnemies.Clear();
        }

        public void LocalUpdate()
        {
            if (_canSpawn && SpawnRateTimer() && NotEnoughEnemies())
            { 
                SpawnEnemy();
            }
        }

        private bool SpawnRateTimer()
        {
            if (Time.time > _timer)
            {
                _timer = Time.time + _currentLevel.SpawnRate;
                return true;
            }
            
            return false;
        }

        private bool NotEnoughEnemies()
        {
            if (_livingEnemies.Count >= _currentLevel.MaxEnemyCount)
            {
                return false;
            }

            return true;
        }

        private void SpawnEnemy()
        {
            var enemy = Object.Instantiate(_currentLevel.EnemyComponents[Random.Range(0,_currentLevel.EnemyComponents.Count)], _enemiesTransofm);
            enemy.transform.position = _currentLevel.SpawnPoints[Random.Range(0, _currentLevel.SpawnPoints.Count)].position;
            enemy.SetTarget(_target.transform);
            
            _livingEnemies.Add(enemy);
        }

        public void KillEnemy(BaseEnemyComponent enemy)
        {
            _livingEnemies.Remove(enemy);
            Object.Destroy(enemy.gameObject);
        }
    }
}