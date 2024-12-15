using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityManager : MonoBehaviour, IAbillityService
{
    public GameObject fireballPrefab;
    public GameObject portalPrefab;
    
    private GameObject _currentAbility;
    public GameObject selectionUI;
    

    public void SetAbilityFireball()
    {
        _currentAbility = fireballPrefab;
        selectionUI.SetActive(false);
    }

    public void SetAbilityPortal()
    {
        _currentAbility = portalPrefab;
        selectionUI.SetActive(false);
    }
    
    public void UseAbility(Transform spawnPoint, Vector2 direction, int targetLayer)
    {
        if (_currentAbility != null)
        {
            GameObject abilityInstance = Instantiate(_currentAbility);
            IAbility abilityScript = abilityInstance.GetComponent<IAbility>();
            if (abilityScript != null)
            {
                abilityScript.Activate(spawnPoint, direction, targetLayer);
            }
        }
        else
        {
            Debug.Log("Select an Ability");
        }
    }

    private void HideSelectionUI()
    {
        selectionUI.SetActive(false);
    }
}
