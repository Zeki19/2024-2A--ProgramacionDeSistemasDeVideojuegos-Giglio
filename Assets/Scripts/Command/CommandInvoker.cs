using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private readonly Queue<ISpawnCommand> _commandQueue = new Queue<ISpawnCommand>();

    public void ExecuteCommand(ISpawnCommand command)
    {
        command.Execute();
        _commandQueue.Enqueue(command);
    }

    public void ClearCommands()
    {
        _commandQueue.Clear();
    }
}
