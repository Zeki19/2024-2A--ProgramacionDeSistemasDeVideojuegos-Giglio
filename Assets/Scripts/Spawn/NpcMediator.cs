using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class NpcMediator : MonoBehaviour
{
    public static NpcMediator Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public AbstractFactory factory;
    public Spawner spawner;
    public PoolManager pool;

    [SerializeField] private bool _isEnemy;

    public void GetRanged()
    {
        SpawnUnit(UnitClass.Ranged, _isEnemy);
    }
    
    public void GetMelee()
    {
       SpawnUnit(UnitClass.Melee, _isEnemy);
    }

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
        }
        else
        {
            spawner.SpawnUnit(unit, isEnemy);
        }
    }
    
    public FireballAbility GetFireball()
    {
        GameObject fireball = pool.GetFromPoolByName("Arrow");
        if (!fireball)
        {
            fireball = factory.CreateArrow();
            fireball.name = "fireball";
        }
        
        fireball.transform.SetParent(pool.gameObject.transform);
        return fireball.GetComponent<FireballAbility>();
    }

}
