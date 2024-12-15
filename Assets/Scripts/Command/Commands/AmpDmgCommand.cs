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
        _player.damage = 100;
    }
}
