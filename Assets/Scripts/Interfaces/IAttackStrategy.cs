using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackStrategy
{
    void Attack(Unit npc, Collider2D target);
}
