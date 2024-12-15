using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Units;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDisplay : MonoBehaviour
{
    [Header("")]
    [SerializeField] private Toggle enemyToggle;
    [SerializeField] private Slider amountSlider;
    [SerializeField] private TMP_Text amountNum;
    [SerializeField] private TMP_Dropdown classDropdown;
    [SerializeField] private Button spawnButton;
    
    private ICommandService _manager;

    private bool Visibility;
    
    private void Start()
    {
        _manager = ServiceLocator.Instance.GetService<ICommandService>();
        
        amountNum.text = amountSlider.value.ToString();
        
        PopulateDropdown();
        
        spawnButton.onClick.AddListener(OnSpawnButtonClicked);
        
        amountSlider.onValueChanged.AddListener(value =>
        {
            amountNum.text = value.ToString();
        });
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    private void PopulateDropdown()
    {
        classDropdown.ClearOptions();
        
        var unitClasses = Enum.GetNames(typeof(UnitClass));
        
        classDropdown.AddOptions(new List<string>(unitClasses));
    }

    private void OnSpawnButtonClicked()
    {
        bool isEnemy = enemyToggle.isOn;
        int amount = (int)amountSlider.value;
        string unitClass = classDropdown.options[classDropdown.value].text;
        
        Enum.TryParse(unitClass, out UnitClass result);
        
        _manager.SpawnUnit(result, isEnemy, amount, null);
    }
}
