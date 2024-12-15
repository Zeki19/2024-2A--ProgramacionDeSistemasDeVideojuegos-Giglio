using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInstaller : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> services = new List<MonoBehaviour>();
    private void Awake()
    {
        foreach (var service in services)
        {
            Type serviceType = service.GetType();
            Type serviceInterface = serviceType.GetInterfaces()[0];

            ServiceLocator.Register(serviceInterface, service);
        }
    }
}
