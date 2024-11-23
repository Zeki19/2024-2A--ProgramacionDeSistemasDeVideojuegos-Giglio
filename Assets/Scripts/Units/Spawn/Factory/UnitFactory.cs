using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
public class UnitFactory : MonoBehaviour
{
    [Header("Unit pool")]
    public UnitPool pool;
    
    [Header("Unit Prefab")]
    [SerializeField] private GameObject unitPrefab;
    
    [Header("Unit Info")]
    [SerializeField] private UnitInfo meleeUnitInfo;
    [SerializeField] private UnitInfo rangedUnitInfo;

    
    public GameObject CreateUnit(UnitClass unitClass, bool isEnemy)
    {
        GameObject unit = pool.GetInactiveUnit() ?? Instantiate(unitPrefab, pool.transform, true);

        UnitInfo unitInfo = unitClass switch
        {
            UnitClass.Melee => meleeUnitInfo,
            UnitClass.Ranged => rangedUnitInfo,
            _ => throw new System.ArgumentException($"Unsupported UnitClass: {unitClass}")
        };
        
        UnitInitializer initializer = unit.GetComponent<UnitInitializer>();
        initializer.InitializeUnit(unitInfo, isEnemy);
        
        return unit;
    }
}
