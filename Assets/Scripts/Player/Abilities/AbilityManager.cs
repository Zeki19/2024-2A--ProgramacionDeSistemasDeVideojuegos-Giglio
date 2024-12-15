using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityManager : MonoBehaviour, IAbillityService
{
    private string _currentAbility = "None";
    public GameObject selectionUI;

    private IMediatorService _mediator;
    private ICommandService _command;

    private void Start()
    {
        _mediator = ServiceLocator.Instance.GetService<IMediatorService>();
        _command = ServiceLocator.Instance.GetService<ICommandService>();
    }
    
    public void SetAbilityFireball()
    {
        _currentAbility = "Fireball";
        SelectedAbility();
    }

    public void SetAbilityPortal()
    {
        _currentAbility = "Portal";
        SelectedAbility();
    }

    public void UseAbility(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        if (_currentAbility != "None")
        {
            IAbility abilityInstance = _mediator.GetAbility(_currentAbility);
            
            abilityInstance?.Activate(spawnPoint, direction, targetLayer);
        }
        else
        {
            Debug.Log("Select an Ability");
        }
    }

    private void SelectedAbility()
    {
        _command.MessageBox("Selected " + _currentAbility + " as the Ability! Use it with 'E'");
        //selectionUI.SetActive(false);
    }
}
