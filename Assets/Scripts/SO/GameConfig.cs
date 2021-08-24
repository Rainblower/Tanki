using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SO/GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private TankViewController _tank = default;

        public TankViewController Tank => _tank;
    }
}