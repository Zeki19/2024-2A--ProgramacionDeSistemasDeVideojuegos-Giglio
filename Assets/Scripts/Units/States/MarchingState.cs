using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingState : IState
{
    public void EnterState(NpcManager npc)
    {
        npc.CanMove = true;
    }

    public void UpdateState(NpcManager npc)
    {
        npc.target = Physics2D.OverlapCircle(npc.transform.position, npc.Range, npc.TargetLayer);

        if (npc.target != null)
        {
            npc.ChangeState(new AttackingState());
        }
    }

    public void ExitState(NpcManager npc)
    {
        npc.CanMove = false;
    }
}
