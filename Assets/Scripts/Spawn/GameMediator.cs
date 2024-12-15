using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class GameMediator : MonoBehaviour, IMediatorService
{
    public AbstractFactory factory;
    public Spawner spawner;
    public PoolManager pool;
    private bool _isEnemy;
    
    public Arrow GetArrow()
    {
        GameObject arrow = pool.GetFromPoolByName("Arrow");
        if (!arrow)
        {
            arrow = factory.CreateArrow();
            arrow.name = "Arrow";
        }
        
        arrow.transform.SetParent(pool.gameObject.transform);
        arrow.SetActive(true);
        return arrow.GetComponent<Arrow>();
    }
    
    public void SpawnUnit(UnitClass unitClass, bool isEnemy, Vector3? spawnPosition = null)
    {
            GameObject unit = pool.GetFromPoolByName(unitClass.ToString());
            if (!unit)
            {
                unit = factory.CreateUnit();
                unit.name = unitClass.ToString();
            }

            unit.transform.SetParent(pool.gameObject.transform);
        
            NpcManager npcManager = unit.GetComponent<NpcManager>();

            npcManager.Initialize(unitClass, isEnemy);

            if (spawnPosition.HasValue)
            {
                unit.transform.position = spawnPosition.Value;
                unit.SetActive(true);
            }
            else
            {
                spawner.SpawnUnit(unit, isEnemy);
            }
    }
    

}
