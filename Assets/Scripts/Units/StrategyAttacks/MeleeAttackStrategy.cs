using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackStrategy : IAttackStrategy
{
    public void Attack(Unit npc, Collider2D target)
    {
        var targetHealth = target.GetComponent<IHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(npc.Damage);
        }
    }
}
