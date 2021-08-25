using Core;
using SO;
using UnityEngine;

public class CoreAplication : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig = default;

    private SystemController _systemController;
    
    private void Start()
    {
        _systemController = new SystemController(transform,_gameConfig);
    }

    private void Update()
    {
        _systemController.LocalUpdate();
    }
}
