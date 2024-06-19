using System;
using ServiceLocatorSystem;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour, IService
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}