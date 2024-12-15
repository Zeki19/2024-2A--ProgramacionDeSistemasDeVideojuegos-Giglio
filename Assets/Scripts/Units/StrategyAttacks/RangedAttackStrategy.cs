using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackStrategy : IAttackStrategy
{
    private GameObject _projectilePrefab;
    
    public void Attack(NpcManager npc, Collider2D target)
    {
        var arrow = ServiceLocator.Instance.GetService<IMediatorService>().GetArrow();
        arrow.ShootArrow(npc.transform, target, npc.Damage);
    }
}
