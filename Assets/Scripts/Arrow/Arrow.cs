using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Collider2D _target;
    private IHealth _targetHealth;
    private int _damage;
    
    private bool _isFlying;
    private float _speed = 5f;
    

    public void ShootArrow(Transform shootingPosition, Collider2D targetHit, int setDamage)
    {
        transform.position = shootingPosition.position;
        _target = targetHit;
        _targetHealth = targetHit.GetComponent<IHealth>();
        _damage = setDamage;
        _isFlying = true;
    }

    private void Update()
    {
        if (_isFlying)
        {
            MoveTowardsTarget();
        }
    }
    
    private void MoveTowardsTarget()
    {
        if (_target is null)
        {
            DeactivateArrow();
        }
        else
        {
            Vector2 targetPosition = _target.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                HitTarget();
            }
            
        }
    }
    
    private void HitTarget()
    {
        _targetHealth?.TakeDamage(_damage);

        DeactivateArrow();
    }
    
    private void DeactivateArrow()
    {
        _isFlying = false;
        ServiceLocator.Instance.GetService<IPoolService>().ReturnToPool(gameObject);
    }
}

