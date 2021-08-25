using System.Collections.Generic;
using SO;
using UnityEngine;
using Views.Enemies;

namespace Controllers
{
    public class EnemyController
    {
        private GameConfig _gameConfig;
        
        private TankViewController _target;
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

        public void Start(TankViewController target, LevelComponent level)
        {
            _target = target;
            _currentLevel = level;

            GameObject go = new GameObject("Enemies");
            go.transform.parent = _parent;
            _enemiesTransofm = go.transform;
            
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            _canSpawn = true;
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
            var enemy = Object.Instantiate(_currentLevel.EnemyComponents[Random.Range(0,_currentLevel.EnemyComponents.Count-1)], _enemiesTransofm);
            enemy.transform.position = _currentLevel.SpawnPoints[Random.Range(0, _currentLevel.SpawnPoints.Count - 1)].position;
            enemy.SetTarget(_target.transform);
            
            _livingEnemies.Add(enemy);
        }
    }
}