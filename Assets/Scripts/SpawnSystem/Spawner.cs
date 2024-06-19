using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour, IService
    {
        public GameObject Spawn(GameObject obj)
        {
            return Instantiate(obj);
        }

        public GameObject Spawn(GameObject obj, Transform parent)
        {
            return Instantiate(obj, parent);
        }

        public GameObject Spawn(GameObject obj, Vector2 position)
        {
            return Instantiate(obj, position, Quaternion.identity);
        }

        public GameObject SpawnUI(GameObject obj, Vector2 position, Transform parent)
        {
            GameObject newObj =  Instantiate(obj, parent);
            newObj.GetComponent<RectTransform>().anchoredPosition = position;

            return newObj;
        }
        
        public T Spawn<T>(GameObject obj) where T : Component
        {
            return Instantiate(obj).GetComponent<T>();
        }

        public T Spawn<T>(GameObject obj, Transform parent) where T : Component
        {
            return Instantiate(obj, parent).GetComponent<T>();
        }

        public T Spawn<T>(GameObject obj, Vector2 position) where T : Component
        {
            return Instantiate(obj, position, Quaternion.identity).GetComponent<T>();
        }

        public void DestroyHandle(GameObject obj)
        {
            Destroy(obj);
        }
    }
}