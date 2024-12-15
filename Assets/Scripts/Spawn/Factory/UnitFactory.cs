using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UnitFactory : MonoBehaviour, IFactory
{
    [Header("Unit Prefab")]
    public GameObject prefab;
    
    public GameObject Create([CanBeNull] string name)
    {
        GameObject unit = Instantiate(prefab);
        unit.SetActive(false);
        
        return unit;
    }
}
