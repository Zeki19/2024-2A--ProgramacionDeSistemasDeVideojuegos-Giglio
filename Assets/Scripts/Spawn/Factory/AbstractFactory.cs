using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    private readonly Dictionary<Type, IFactory> _factories = new Dictionary<Type, IFactory>();
    [Header("Arrow Factory")]
    [SerializeField] private ArrowFactory arrowFactory;
    [Header("Unit Factory")]
    [SerializeField] private UnitFactory _unitFactory;

    public GameObject CreateArrow() => arrowFactory.Create().gameObject;
    public GameObject CreateUnit() => _unitFactory.Create().gameObject;
    
}
