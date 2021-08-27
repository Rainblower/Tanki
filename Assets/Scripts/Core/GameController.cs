using Controllers;
using SO;
using UnityEngine;

namespace Core
{
    public class GameController: BaseController
    {
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public LevelController LevelController { get; private set; }
        public EnemyController EnemyController { get; private set; }
        public CollisionController CollisionController { get; private set; }
        public DamageController DamageController { get; private set; }
        public ObjectsPooler ObjectsPooler { get; private set; }
        
        
        private bool _gameStarted;
        
        public GameController(Transform transform, GameConfig gameConfig)
        {
            InputController = new InputController();
            PlayerController = new PlayerController(transform,gameConfig);
            LevelController = new LevelController(transform,gameConfig);
            EnemyController = new EnemyController(transform,gameConfig);
            CollisionController = new CollisionController(this);
            DamageController = new DamageController();

            ObjectsPooler = Object.Instantiate(gameConfig.ObjectsPooler, transform);
            
            StartGame();

            InputController.RestartGame += RestartGame;
        }

        public void StartGame()
        {
            LevelController.StartLevel(0);
            
            PlayerController.SpawnPlayer();
            PlayerController.SetupInput(InputController);

            EnemyController.Start(PlayerController.Player, LevelController.CurrentLevel);
            
            _gameStarted = true;
        }

        public void LocalUpdate()
        {
            if (_gameStarted)
            {
                InputController.LocalUpdate();
                EnemyController.LocalUpdate();
            }
        }

        public void EndGame()
        {
            EnemyController.EndGame();
            PlayerController.EndGame(InputController);
        }

        public void RestartGame()
        {
            Debug.LogWarning("Restarting game...");
            EndGame();
            StartGame();
        }
    }
}