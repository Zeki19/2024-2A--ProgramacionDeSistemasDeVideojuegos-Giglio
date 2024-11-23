using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using Units;
using UnityEngine.Serialization;

public class UnitMediator : MonoBehaviour
{
    public static UnitMediator Instance;
    
    public Spawner spawner;
    public UnitFactory factory;
    
    private void Awake()
    {
        Instance = this;
    }

    public void RequestUnit(UnitClass unitClass, bool isEnemy, Vector3? spawnPosition = null)
    {
        GameObject unit = factory.CreateUnit(unitClass, isEnemy);
        
        if (spawnPosition.HasValue)
        {
            unit.transform.position = spawnPosition.Value;
        }
        else
        {
            spawner.SpawnUnit(unit, isEnemy);
        }
        
        unit.SetActive(true);
    }

}
