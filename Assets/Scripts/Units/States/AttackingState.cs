using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class AttackingState : IState
{
    public void EnterState(Unit npc)
    {
        npc.CanMove = false;

        if (!npc.CanAttack) return;
        npc.CanAttack = false;
        npc.PerformAttack();
    }

    public void UpdateState(Unit npc)
    {
        if (!npc.CanAttack)
        {
            npc.ChangeState(new CooldownState());
        }
    }

    public void ExitState(Unit npc)
    {
        npc.CanAttack = false;
    }
}
