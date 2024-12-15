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
    public float lifetime = 3f;
    
    private ICommandService _mediator;

    private void Awake()
    {
        _mediator = ServiceLocator.Instance.GetService<ICommandService>();
    }

    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        transform.position = spawnPoint.position + new Vector3(-1.5f , 0 , 0);
        int rand = Random.Range(1, maxUnits);
        
        _mediator?.SpawnUnit(GetRandomUnitClass(), isEnemy, rand ,transform);
        
        Destroy(gameObject, lifetime);
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
