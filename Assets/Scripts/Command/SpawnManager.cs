using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private CommandInvoker _invoker;

    private void Awake()
    {
        _invoker = new CommandInvoker();
    }

    public void SpawnAllyMelee()
    {
        var command = new SpawnAllyMeleeCommand(NpcMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnAllyRanged()
    {
        var command = new SpawnAllyRangedCommand(NpcMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnEnemyMelee()
    {
        var command = new SpawnEnemyMeleeCommand(NpcMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnEnemyRanged()
    {
        var command = new SpawnEnemyRangedCommand(NpcMediator.Instance);
        _invoker.ExecuteCommand(command);
    }
    
    public void SpawnWave()
    {
        var command = new SpawnWaveCommand(NpcMediator.Instance, this);
        _invoker.ExecuteCommand(command);
    }
}
