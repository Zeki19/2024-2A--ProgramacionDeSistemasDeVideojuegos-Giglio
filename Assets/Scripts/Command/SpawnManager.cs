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
        var command = new SpawnAllyMeleeCommand(UnitMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnAllyRanged()
    {
        var command = new SpawnAllyRangedCommand(UnitMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnEnemyMelee()
    {
        var command = new SpawnEnemyMeleeCommand(UnitMediator.Instance);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnEnemyRanged()
    {
        var command = new SpawnEnemyRangedCommand(UnitMediator.Instance);
        _invoker.ExecuteCommand(command);
    }
    
    public void SpawnWave()
    {
        var command = new SpawnWaveCommand(UnitMediator.Instance, this);
        _invoker.ExecuteCommand(command);
    }
}
