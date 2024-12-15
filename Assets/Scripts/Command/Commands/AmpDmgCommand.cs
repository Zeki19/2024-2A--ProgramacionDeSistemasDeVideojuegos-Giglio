using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpDmgCommand : ICommand
{
    private Player _player;
    
    public AmpDmgCommand(GameObject player)
    {
        _player = player.GetComponent<Player>();
    }
    public void Execute()
    {
        ServiceLocator.Instance.GetService<ICommandService>().MessageBox("Player Dmg set to KILL");
        _player.damage = 1000;
    }
}
