using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    private Dictionary<string, Queue<GameObject>> _pools = new Dictionary<string, Queue<GameObject>>();
    
    public GameObject GetFromPoolbyType(GameObject prefab)
    {
        string key = prefab.name;

        if (!_pools.ContainsKey(key) || _pools[key].Count <= 0) return null;
        GameObject obj = _pools[key].Dequeue();
        obj.SetActive(true);
        return obj;

    }
    
    public void ReturnToPool(GameObject obj)
    {
        string key = obj.name;

        if (!_pools.ContainsKey(key))
        {
            _pools[key] = new Queue<GameObject>();
        }

        obj.SetActive(false);
        _pools[key].Enqueue(obj);
    }
    
    public GameObject GetFromPoolByName(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) && _pools[prefabName].Count > 0)
        {
            GameObject obj = _pools[prefabName].Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return null;
    }
}
