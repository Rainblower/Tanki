using Controllers;
using SO;
using UnityEngine;

namespace Core
{
    public class GameController: BaseController
    {
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }

        private bool _gameStarted;
        
        public GameController(Transform transform, GameConfig gameConfig)
        {
            InputController = new InputController();
            PlayerController = new PlayerController(transform,gameConfig);
            
            StartGame();
        }

        public void StartGame()
        {
            PlayerController.SpawnPlayer();
            PlayerController.SetupInput(InputController);
            
            _gameStarted = true;
        }

        public void LocalUpdate()
        {
            if (_gameStarted)
            {
                InputController.LocalUpdate();
            }
        }
    }
}