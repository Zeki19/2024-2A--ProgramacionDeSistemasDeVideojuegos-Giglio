using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using Unity.VisualScripting;

public class UnitInitializer : MonoBehaviour
{
    [SerializeField] private UnitInfo meleeUnitInfo;
    [SerializeField] private UnitInfo rangedUnitInfo;

    // Reference to all scripts that need UnitInfo
    private UnitMovement unitMovement;
    private UnitHealth unitHealth;
    private ClassStates classStates;
    
    // Initialize all components with UnitInfo
    public void InitializeUnit(UnitInfo unitInfo, bool isEnemy)
    {
        unitMovement = GetComponent<UnitMovement>();
        unitHealth = GetComponent<UnitHealth>();
        classStates = GetComponent<ClassStates>();
        
        if (classStates == null || unitMovement == null || unitHealth == null) return;
        unitMovement.InitializeUnit(unitInfo,isEnemy);
        classStates.InitializeUnit(unitInfo);
        unitHealth.InitializeUnit(unitInfo);
        
        classStates.BeginUnit();
        
        gameObject.SetActive(true);
    }
}
