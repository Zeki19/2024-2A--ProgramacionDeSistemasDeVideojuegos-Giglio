using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void EnterState(NpcManager npc);
    void UpdateState(NpcManager npc);
    void ExitState(NpcManager npc);
}
