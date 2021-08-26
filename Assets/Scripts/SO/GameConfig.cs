using System.Collections.Generic;
using Core;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SO/GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private TankViewController _tank = default;
        [SerializeField] private ObjectsPooler _objectsPooler = default;
        [SerializeField] private List<LevelComponent> _levels = default;
        

        public TankViewController Tank => _tank;
        public List<LevelComponent> Levels => _levels;
        public ObjectsPooler ObjectsPooler => _objectsPooler;
    }
}