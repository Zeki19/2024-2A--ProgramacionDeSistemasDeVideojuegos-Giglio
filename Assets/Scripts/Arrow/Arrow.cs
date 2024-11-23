using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Collider2D target;
    private IHealth _targetHealth;
    private int damage;
    private bool isFlying;
    
    [SerializeField] private float speed = 5f;
    
    public void ShootArrow(Transform shootingPosition, Collider2D targetHit, int setDamage)
    {
        transform.position = shootingPosition.position;
        target = targetHit;
        _targetHealth = targetHit.GetComponent<IHealth>();
        damage = setDamage;
        isFlying = true;
    }

    private void Update()
    {
        if (isFlying)
        {
            MoveTowardsTarget();
        }
    }
    
    private void MoveTowardsTarget()
    {
        if (target is null)
        {
            DeactivateArrow();
            
        }
        else
        {
            Vector2 targetPosition = target.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                HitTarget();
            }
            
        }
    }
    
    private void HitTarget()
    {
        _targetHealth?.TakeDamage(damage);

        DeactivateArrow();
    }
    
    private void DeactivateArrow()
    {
        isFlying = false;
        ArrowManager.Instance.ReturnArrow(gameObject);
    }
}

