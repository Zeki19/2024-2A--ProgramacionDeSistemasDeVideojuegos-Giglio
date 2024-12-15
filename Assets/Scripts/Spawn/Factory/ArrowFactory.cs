using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour, IFactory
{
    [Header("Arrow Prefab")]
    [SerializeField] private GameObject prefab;
    
    public GameObject Create()
    {
        GameObject arrow = Instantiate(prefab);
        arrow.SetActive(false);
        
        return arrow;
    }
}
