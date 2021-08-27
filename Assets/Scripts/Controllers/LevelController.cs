using SO;
using UnityEngine;

namespace Controllers
{
    public class LevelController
    {
        private Transform _parent;
        private GameConfig _gameConfig;

        private LevelComponent _currentLevel;

        public LevelComponent CurrentLevel => _currentLevel;
        
        public LevelController(Transform transform, GameConfig gameConfig)
        {
            _parent = transform;
            _gameConfig = gameConfig;
        }

        public void StartLevel(int index)
        {
            if (_currentLevel != null)
            {
                Object.Destroy(_currentLevel.gameObject);
            }
            
            var level = _gameConfig.Levels[index];

            _currentLevel = Object.Instantiate(level, _parent);
        }
    }
}