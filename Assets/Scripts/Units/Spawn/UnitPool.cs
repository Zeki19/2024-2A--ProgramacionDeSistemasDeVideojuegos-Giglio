using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
public class UnitPool : MonoBehaviour //Lazy Singleton
{
    private static UnitPool _instance;
    public static UnitPool Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<UnitPool>();
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("UnitPool");
                _instance = singletonObject.AddComponent<UnitPool>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
    private Queue<GameObject> _pool = new Queue<GameObject>();
    
    public GameObject GetInactiveUnit()
    {
        if (_pool.Count <= 0) return null;
        GameObject unit = _pool.Dequeue();
        return unit;
    }

    public void ReturnUnit(GameObject unit)
    {
        unit.SetActive(false);
        
        _pool.Enqueue(unit);
    }
}
