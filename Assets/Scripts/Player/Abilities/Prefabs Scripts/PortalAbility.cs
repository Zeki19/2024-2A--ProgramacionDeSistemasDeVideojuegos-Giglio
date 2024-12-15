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
    private IMediatorService _mediator;

    private void Start()
    {
        _mediator = ServiceLocator.Instance.GetService<IMediatorService>();
    }

    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        transform.position = spawnPoint.position + new Vector3(-1.5f , 0 , 0);
        int rand = Random.Range(0, maxUnits);

        for (int i = 0; i < rand; i++)
        {
            _mediator.SpawnUnit(GetRandomUnitClass(), isEnemy, transform.position);
        }
        
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
