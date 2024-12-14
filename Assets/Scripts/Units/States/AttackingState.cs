using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class AttackingState : IState
{
    public void EnterState(NpcManager npc)
    {
        npc.CanMove = false;

        if (!npc.CanAttack) return;
        npc.CanAttack = false;
        npc.PerformAttack();
    }

    public void UpdateState(NpcManager npc)
    {
        if (!npc.CanAttack)
        {
            npc.ChangeState(new CooldownState());
        }
    }

    public void ExitState(NpcManager npc)
    {
        npc.CanAttack = false;
    }
}
