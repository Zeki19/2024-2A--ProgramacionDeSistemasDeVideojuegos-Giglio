using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingState : IState
{
    public void EnterState(Unit npc)
    {
        npc.CanMove = true;
    }

    public void UpdateState(Unit npc)
    {
        npc.target = Physics2D.OverlapCircle(npc.transform.position, npc.Range, npc.TargetLayer);

        if (npc.target != null)
        {
            npc.ChangeState(new AttackingState());
        }
    }

    public void ExitState(Unit npc)
    {
        npc.CanMove = false;
    }
}
