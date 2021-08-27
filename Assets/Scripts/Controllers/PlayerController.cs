using Models;
using SO;
using UnityEngine;

namespace Controllers
{
    public class PlayerController
    {
        private Transform _playerTransform;
        private GameConfig _gameConfig;

        private TankComponent _tankComponent;

        public TankComponent Player => _tankComponent;

        public PlayerController(Transform transform, GameConfig gameConfig)
        {
            _gameConfig = gameConfig;

            GameObject go = new GameObject("Player");
            go.transform.parent = transform;

            _playerTransform = go.transform;
        }


        public void SpawnPlayer()
        {
            if (_tankComponent != null)
            {
                Object.Destroy(_tankComponent.gameObject);
            }

            TankModel tankModel = new TankModel();
            _tankComponent = Object.Instantiate(_gameConfig.Tank, _playerTransform);
            _tankComponent.Init(tankModel);
        }

        public void SetupInput(InputController inputController)
        {
            inputController.Move += _tankComponent.MoveHandler;
            inputController.Rotate += _tankComponent.RotateHandler;
            inputController.Fire += _tankComponent.FireHandler;
            inputController.NextWeapon += _tankComponent.NextWeaponHandler;
            inputController.PrevWeapon += _tankComponent.PrevWeaponHandler;
        }

        public void EndGame(InputController inputController)
        {
            inputController.Move -= _tankComponent.MoveHandler;
            inputController.Rotate -= _tankComponent.RotateHandler;
            inputController.Fire -= _tankComponent.FireHandler;
            inputController.NextWeapon -= _tankComponent.NextWeaponHandler;
            inputController.PrevWeapon -= _tankComponent.PrevWeaponHandler;
        }
    }
}