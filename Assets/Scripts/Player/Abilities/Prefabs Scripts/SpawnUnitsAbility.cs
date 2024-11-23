using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

public class PortalAbility : MonoBehaviour, IAbility
{
    [Header("Spawn Settings")]
    public int maxUnits = 3;
    public bool isEnemy = false;
    public float cooldown = 10f;
    public float spawnInterval = 0.5f;
    
    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        transform.position = spawnPoint.position + new Vector3(-1.5f , 0 , 0);
        
        int unitsToSpawn = Random.Range(1, maxUnits + 1);
        
        StartCoroutine(SpawnUnits(unitsToSpawn));
    }
    
    private IEnumerator SpawnUnits(int unitsToSpawn)
    {
        for (int i = 0; i < unitsToSpawn; i++)
        {
            UnitClass unitClass = GetRandomUnitClass();
            
            UnitMediator.Instance.RequestUnit(unitClass, isEnemy, transform.position);
            
            yield return new WaitForSeconds(spawnInterval);
        }
        
        Destroy(gameObject);
    }

    public float GetCooldown()
    {
        return cooldown;
    }
    
    private UnitClass GetRandomUnitClass()
    {
        var unitClasses = Enum.GetValues(typeof(UnitClass));
        
        UnitClass randomClass = (UnitClass)unitClasses.GetValue(UnityEngine.Random.Range(0, unitClasses.Length));
        return randomClass;
    }
}
