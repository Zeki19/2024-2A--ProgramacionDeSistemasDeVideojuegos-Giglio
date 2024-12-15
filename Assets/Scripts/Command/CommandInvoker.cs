using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandQueue.Enqueue(command);
    }

    public void ClearCommands()
    {
        _commandQueue.Clear();
    }
}
