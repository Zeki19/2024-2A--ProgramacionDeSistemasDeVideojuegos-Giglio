using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

public class PortalAbility : MonoBehaviour, IAbility
{
    [Header("Portal Settings")]
    public int maxUnits = 3;
    public bool isEnemy = false;
    public float cooldown = 10f;
    public float lifetime = 3f;
    public float spinSpeed = 100f;
    
    private ICommandService _mediator;

    private void OnEnable()
    {
        _mediator = ServiceLocator.Instance.GetService<ICommandService>();
    }
    private void Update()
    {
        RotatePortal();
    }
    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        SetupPortal(spawnPoint);
        SpawnUnits();
        DestroyPortalAfterLifetime();
    }

    #region Spinning Logic

    private void RotatePortal()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }

    #endregion

    #region Setup and Spawn

    private void SetupPortal(Transform spawnPoint)
    {
        transform.position = spawnPoint.position + new Vector3(-1.5f, 0, 0);
    }
    private void SpawnUnits()
    {
        int rand = Random.Range(1, maxUnits + 1);

        _mediator?.SpawnUnit(UnitClass.Random, isEnemy, rand, transform);
    }

    #endregion
    
    #region Utility Methods
    private void DestroyPortalAfterLifetime()
    {
        Destroy(gameObject, lifetime);
    }
    public float GetCooldown()
    {
        return cooldown;
    }
    #endregion
}
