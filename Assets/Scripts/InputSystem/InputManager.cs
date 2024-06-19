using System;
using ServiceLocatorSystem;
using UI;
using UnityEngine;

namespace InputSystem
{
    public class InputManager : MonoBehaviour, IService
    {
        [SerializeField] private InputConfig inputConfig;

        private PauseMenu _pauseMenu;

        public void Initialize()
        {
            _pauseMenu = ServiceLocator.Instance.Get<PauseMenu>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(inputConfig.pauseKey))
            {
                _pauseMenu.gameObject.SetActive(!_pauseMenu.gameObject.activeSelf);
            }
        }
    }
}