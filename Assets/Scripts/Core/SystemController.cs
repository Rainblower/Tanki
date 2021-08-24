using SO;
using UnityEngine;

namespace Core
{
    public class SystemController: BaseController, ISystemController
    {
        public GameController GameController { get; private set; }

        public SystemController(Transform parent,GameConfig gameConfig)
        {
            SystemController = this;

            GameController = new GameController(parent,gameConfig);
        }

        public void LocalUpdate()
        {
            GameController.LocalUpdate();
        }
    }
}