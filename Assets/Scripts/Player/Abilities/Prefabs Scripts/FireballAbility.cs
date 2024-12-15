using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : MonoBehaviour, IAbility
{
    [Header("Fireball settings")]
    public float projectileSpeed;
    public float lifetime;
    public int initialDamage;
    public int maxUnitsHit;
    public float cooldown = 5f;
    public float damageFallOffPercentage = 20f;
    public float scaleReductionPerHit = 0.25f;

    private int _currentDamage;
    private int _unitsHit;
    private int _targetLayer = 6;
    private Vector2 _direction;

    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        InitializeProjectile(spawnPoint, direction, targetLayer);
    }
    private void Update()
    {
        MoveProjectile();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsTargetHit(other)) return;
        HandleHit(other);

        if (_unitsHit >= maxUnitsHit)
        {
            DestroyFireball();
        }
    }
    
    #region Initialization and Movement
    private void InitializeProjectile(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        transform.position = spawnPoint.position;

        _direction = direction.normalized;
        _targetLayer = targetLayer;
        _unitsHit = 0;
        _currentDamage = initialDamage;

        Destroy(gameObject, lifetime);
    }

    private void MoveProjectile()
    {
        transform.Translate(_direction * (projectileSpeed * Time.deltaTime));
    }

    #endregion
    
    #region Hit Handling
    private bool IsTargetHit(Collider2D col)
    {
        return col.gameObject.layer == _targetLayer && col.GetComponent<IHealth>() != null;
    }
    private void HandleHit(Collider2D target)
    {
        IHealth targetHealth = target.GetComponent<IHealth>();
        targetHealth.TakeDamage(_currentDamage);
        
        _unitsHit++;
        _currentDamage = CalculateFallOffDamage();
        
        ScaleDownFireball();
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Utility Methods

    private int CalculateFallOffDamage()
    {
        float fallOffMultiplier = damageFallOffPercentage / 100f;
        return Mathf.RoundToInt(initialDamage - (fallOffMultiplier * _unitsHit));
    }

    private void ScaleDownFireball()
    {
        transform.localScale -= new Vector3(scaleReductionPerHit, scaleReductionPerHit, scaleReductionPerHit);
        
        if (transform.localScale.x < 0.1f || transform.localScale.y < 0.1f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public float GetCooldown()
    {
        return cooldown;
    }

    #endregion
}
