using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour, ICommandService
{
    private CommandInvoker _invoker;
    [SerializeField] private GameObject Player;

    private void Awake()
    {
        _invoker = new CommandInvoker();
    }

    public void SpawnUnit(Units.UnitClass unitClass, bool isEnemy, int amount)
    {
        var command = new SpawnUnitCommand(unitClass, isEnemy, amount);
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
}
