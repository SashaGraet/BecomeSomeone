using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorSystem
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance { get; private set; }

        private readonly Dictionary<string, IService> services = new();

        public static void Initialize()
        {
            Instance = new ServiceLocator();
        }

        public void Add<T>(T service) where T : IService
        {
            if (!services.TryAdd(typeof(T).Name, service))
            {
                Debug.LogError($"Service {typeof(T).Name} already exist");
            }
        }

        public T Get<T>() where T : IService
        {
            if (services.TryGetValue(typeof(T).Name, out IService service))
            {
                return (T)service;
            }
            
            Debug.LogError($"Service {typeof(T).Name} doesn't exist");
            throw new Exception();
        }
    }
}