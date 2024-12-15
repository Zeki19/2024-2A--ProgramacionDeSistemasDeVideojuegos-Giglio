using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMediator : MonoBehaviour, IMediatorService
{
    public AbstractFactory factory;
    public SpawnerManager spawner;
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
        if (unitClass == UnitClass.Random)
        {
            unitClass = GetRandomUnitClass();
        }
        
        GameObject unit = pool.GetFromPoolByName(unitClass.ToString());
        if (!unit)
        {
                unit = factory.CreateUnit();
                unit.name = unitClass.ToString();
        }

        unit.transform.SetParent(pool.gameObject.transform);
        
        Unit npcManager = unit.GetComponent<Unit>();

        npcManager.Initialize(unitClass, isEnemy);
            
        spawner.SpawnUnit(unit, isEnemy, spawnPosition);
    }
    private UnitClass GetRandomUnitClass()
    {
        var unitClasses = Enum.GetValues(typeof(UnitClass));
        return (UnitClass)unitClasses.GetValue(Random.Range(0, unitClasses.Length-1));
    }
    public IAbility GetAbility(string abilityName)
    {
        GameObject ability = pool.GetFromPoolByName(abilityName);
        if (!ability)
        {
            ability = factory.CreateAbility(abilityName);
            ability.name = abilityName;
            ability.transform.SetParent(pool.gameObject.transform);
        }
        
        ability.SetActive(true);
        return ability.GetComponent<IAbility>();
    }

}
