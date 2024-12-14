using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownState : IState
{
    private float _cooldownTimer;
    
    public void EnterState(NpcManager npc)
    {
        _cooldownTimer = 0f;
        npc.CanMove = false;
    }

    public void UpdateState(NpcManager npc)
    {
        _cooldownTimer += Time.deltaTime;

        if (!(_cooldownTimer >= npc.Cooldown)) return;
       
        if (npc.IsTargetValid())
        {
            npc.ChangeState(new AttackingState());
        }
        else
        {
            npc.ChangeState(new MarchingState());
        }
    }
    
    public void ExitState(NpcManager npc)
    {
        npc.CanMove = false;
        npc.CanAttack = true;
    }
}
