using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public void Register<T>(T serviceInstance)
    {
        if (!services.ContainsKey(typeof(T)))
        {
            services.Add(typeof(T), serviceInstance);
        }
        else
        {
            services[typeof(T)] = serviceInstance;
        }
    }

    public static void Register(Type type, object serviceInstance)
    {
        if (!services.ContainsKey(type))
        {
            services.Add(type, serviceInstance);
        }
        else
        {
            services[type] = serviceInstance;
        }
    }

    public T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out var serviceObject))
        {
            return (T)serviceObject;
        }
        else
        {
            return default;
        }
    }
}
