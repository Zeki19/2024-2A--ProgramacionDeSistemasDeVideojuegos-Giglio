using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackStrategy
{
    void Attack(NpcManager npc, Collider2D target);
}
