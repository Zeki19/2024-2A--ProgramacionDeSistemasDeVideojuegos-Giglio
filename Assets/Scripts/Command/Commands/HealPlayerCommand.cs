using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerCommand : ICommand
{
    private GameObject _player;
    private IHealth _playerHealth;
    
    public HealPlayerCommand(GameObject player)
    {
        _player = player;
        _playerHealth = _player.GetComponent<IHealth>();
    }
    public void Execute()
    {
        ServiceLocator.Instance.GetService<ICommandService>().MessageBox("Player Health set to max");
        _playerHealth.ResetHealth();
    }
}
