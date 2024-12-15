using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Units;
using UnityEngine;

public class CommandManager : MonoBehaviour, ICommandService
{
    private CommandInvoker _invoker;
    [SerializeField] private GameObject Player;

    private void Awake()
    {
        _invoker = new CommandInvoker();
    }

    public void SpawnUnit(UnitClass unitClass, bool isEnemy, int amount, [CanBeNull] Transform pos)
    {
        var command = new SpawnUnitCommand(unitClass, isEnemy, amount, pos);
        _invoker.ExecuteCommand(command);
    }

    public void FullHealPlayer()
    {
        var command = new HealPlayerCommand(Player);
        _invoker.ExecuteCommand(command);
    }

    public void AmpDmgPlayer()
    {
        var command = new AmpDmgCommand(Player);
        _invoker.ExecuteCommand(command);
    }

    public void SpawnRandomUnit(bool isEnemy, int amount)
    {
        var command = new SpawnRandomUnitCommand(isEnemy, amount);
        _invoker.ExecuteCommand(command); 
    }
    
}
