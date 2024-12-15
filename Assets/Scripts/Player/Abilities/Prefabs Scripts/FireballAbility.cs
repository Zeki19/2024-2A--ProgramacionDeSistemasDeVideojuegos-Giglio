using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : MonoBehaviour, IAbility
{
    [Header("Fireball Properties")]
    public float projectileSpeed = 10f;
    public float lifetime = 3f;
    public int initialDamage = 10;
    private int _currentDamage;
    public int maxUnitsHit = 1;
    public float cooldown = 5f;
    public float damageFallOffPercentage = 20f;

    private int _unitsHit;
    private int _targetLayer = 6;
    private Vector2 _direction;

    public void Activate(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        _direction = direction.normalized;
        _targetLayer = targetLayer;
        
        _unitsHit = 0;

        _currentDamage = initialDamage;
        
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        transform.Translate(_direction * (projectileSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _targetLayer)
        {
            IHealth targetHealth = other.GetComponent<IHealth>();
            
            targetHealth.TakeDamage(_currentDamage);
            
            _unitsHit++;
            _currentDamage = CalculateFallOffDamage(initialDamage);

            if (_unitsHit >= maxUnitsHit)
            {
                Destroy(gameObject);
            }
        }
    }
    
    private int CalculateFallOffDamage(int currentDamage)
    {
        var x = (damageFallOffPercentage / 100f);
        return Mathf.RoundToInt(currentDamage - (x*_unitsHit));
    }

    public float GetCooldown()
    {
        return cooldown;
    }
    

    public void Activate(Transform spawnPoint, Vector2 direction, int? targetLayer = null)
    {
        throw new System.NotImplementedException();
    }
}
