using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballFactory : MonoBehaviour, IFactory
{
    [SerializeField] public GameObject prefab;
    
    public GameObject Create()
    {
        GameObject fireball = Instantiate(prefab);
        fireball.SetActive(false);
        
        return fireball;
    }
}
