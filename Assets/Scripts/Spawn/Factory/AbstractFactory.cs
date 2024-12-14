using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractFactory : MonoBehaviour, IAbstractFactory
{
    public static AbstractFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [SerializeField] private ArrowFactory arrowFactory;
    [SerializeField] private UnitFactory _unitFactory;
    [SerializeField] private FireballFactory fireballFactory;
    
    public GameObject CreateArrow() => arrowFactory.Create();
    public GameObject CreateUnit() => _unitFactory.Create();
    public GameObject CreateFireball() => fireballFactory.Create();
}
