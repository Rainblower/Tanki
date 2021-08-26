using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class ObjectsPooler: MonoBehaviour
    {
        [SerializeField] private List<PoolerItemSettings> _poolerSettings = default;

        private static readonly Dictionary<PoolingItemType, List<GameObject>> _objectsPool = new Dictionary<PoolingItemType, List<GameObject>>();
        private static Transform _parent;
        
        public void Init(Transform parent)
        {
            _parent = parent;
            
            _objectsPool.Clear();
            foreach ( var projectileSetting in _poolerSettings ) {
                _objectsPool.Add(projectileSetting.Type, new List<GameObject>());

                for (int j = 0; j < projectileSetting.Quantity; j++)
                {
                    CreateToPool(projectileSetting.Type);
                }

                break;
            }
        }
        
        private bool CreateToPool(PoolingItemType type)
        {
            GameObject baseProjectile = CreateObject( type, _parent );
            if (baseProjectile == null) return false;
            _objectsPool[type].Add( baseProjectile );
            baseProjectile.gameObject.SetActive(false);
            return true;
        }
        
        private GameObject CreateObject(PoolingItemType type, Transform holder) 
        {
            return Instantiate(_poolerSettings.FirstOrDefault(x=>x.Type == type).GameObject, holder);
        }

        public void Start()
        {
            Init(transform);
        }
        
        public T GetFromPool<T>(PoolingItemType type) 
        {
            if (_objectsPool.FirstOrDefault(x=>x.Key == type).Value.Count == 0 )
            {
                if (!CreateToPool(type)){}
            }
            GameObject baseProjectile = _objectsPool[type][0];
            baseProjectile.gameObject.SetActive( true );
            _objectsPool[type].RemoveAt( 0 );
            return baseProjectile.GetComponent<T>();
        }

        public void ReturnToPool(PoolingItemType type, GameObject gameObject) 
        {
            if (gameObject == null) return;
            _objectsPool[type].Add( gameObject );
            gameObject.SetActive( false );
        }
    }

    [Serializable]
    public struct PoolerItemSettings
    {
        public PoolingItemType Type;
        public GameObject GameObject;
        public int Quantity;
    }
    
    [Serializable]
    public enum PoolingItemType
    {
        DefaultProjectile,
    }
}