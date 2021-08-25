using System.Collections.Generic;
using UnityEngine;
using Views.Enemies;

public class LevelComponent : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = default;
    [SerializeField] private int _maxEnemyCount = default;
    [SerializeField] private float _spawnRate = default;
    [SerializeField] private List<BaseEnemyComponent> _enemyComponents = default;
    

    public List<Transform> SpawnPoints => _spawnPoints;
    public int MaxEnemyCount => _maxEnemyCount;
    public float SpawnRate => _spawnRate;
    public List<BaseEnemyComponent> EnemyComponents => _enemyComponents;
}
