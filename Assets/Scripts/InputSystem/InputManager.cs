using System;
using ServiceLocatorSystem;
using UI;
using UI.PauseMenu;
using UnityEngine;

namespace InputSystem
{
    public class InputManager : MonoBehaviour, IService
    {
        [SerializeField] private InputConfig inputConfig;

        private PauseMenuView _pauseMenuView;

        public void Initialize()
        {
            _pauseMenuView = ServiceLocator.Instance.Get<PauseMenuView>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(inputConfig.pauseKey))
            {
                _pauseMenuView.SetActiveHandle();
            }
        }
    }
}