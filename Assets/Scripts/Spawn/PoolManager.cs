using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour, IPoolService
{
    private readonly Dictionary<string, Queue<GameObject>> _pools = new Dictionary<string, Queue<GameObject>>();
    
    public void ReturnToPool(GameObject obj)
    {
        string key = obj.gameObject.name;

        if (!_pools.ContainsKey(key))
        {
            _pools[key] = new Queue<GameObject>();
        }

        obj.gameObject.SetActive(false);
        _pools[key].Enqueue(obj);
    }
    
    public GameObject GetFromPoolByName(string key)
    {
        if (_pools.ContainsKey(key) && _pools[key].Count > 0)
        {

            
            return _pools[key].Dequeue();
        }

        return null;
    }
}
