using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour, IFactory
{
    public GameObject prefab;
    
    public GameObject Create()
    {
        GameObject unit = Instantiate(prefab);
        unit.SetActive(false);
        
        return unit;
    }
}
