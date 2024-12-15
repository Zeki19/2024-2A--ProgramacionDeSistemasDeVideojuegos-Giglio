using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void EnterState(Unit npc);
    void UpdateState(Unit npc);
    void ExitState(Unit npc);
}
