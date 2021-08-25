using Models;
using SO;
using UnityEngine;

namespace Controllers
{
    public class PlayerController
    {
        private Transform _playerTransform;
        private GameConfig _gameConfig;

        private TankViewController _tankViewController;

        public TankViewController Player => _tankViewController;
        
        public PlayerController(Transform transform, GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            
            GameObject go = new GameObject("Player");
            go.transform.parent = transform;

            _playerTransform = go.transform;
        }
        

        public void SpawnPlayer()
        {
            TankModel tankModel = new TankModel();
            _tankViewController = Object.Instantiate(_gameConfig.Tank, _playerTransform);
            _tankViewController.Init(tankModel);
        }

        public void SetupInput(InputController inputController)
        {
            inputController.Move += _tankViewController.MoveHandler;
            inputController.Rotate += _tankViewController.RotateHandler;
            inputController.Fire += _tankViewController.FireHandler;
            inputController.NextWeapon += _tankViewController.NextWeaponHandler;
            inputController.PrevWeapon += _tankViewController.PrevWeaponHandler;
        }
    }
}