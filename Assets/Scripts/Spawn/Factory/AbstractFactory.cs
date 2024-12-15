using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    [Header("Arrow Factory")]
    [SerializeField] private ArrowFactory arrowFactory;
    [Header("Unit Factory")]
    [SerializeField] private UnitFactory unitFactory;
    [Header("Ability Factory")]
    [SerializeField] private AbilityFactory abilityFactory;
    public GameObject CreateArrow() => arrowFactory.Create(null);
    public GameObject CreateUnit() => unitFactory.Create(null);
    public GameObject CreateAbility(string abilityName) => abilityFactory.Create(abilityName);
    
}
