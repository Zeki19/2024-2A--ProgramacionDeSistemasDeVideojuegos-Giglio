using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Units;
using UnityEngine;

public class CommandManager : MonoBehaviour, ICommandService
{
    private CommandInvoker _invoker;
    [SerializeField] private GameObject Player;
    [SerializeField] private TMP_Text board;

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

    public void MessageBox(string message)
    {
        var command = new AlertTextCommand(board, message);
        _invoker.ExecuteCommand(command);
    }
}
