using System.Collections.Generic;
using RolesSystem;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.PauseMenu
{
    public class PauseMenuView : MonoBehaviour, IService
    {
        [SerializeField] private int mainMenuSceneIndex;
        [SerializeField] private int playerHouseSceneIndex;
        [SerializeField] private RolesWindow rolesWindow;
        [SerializeField] private GameObject buttonsPlace;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Initialize()
        {
            rolesWindow.Initialize();
        }

        public void SetActiveHandle()
        {
            if (gameObject.activeSelf == false)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneIndex);
        }

        public void RestartDay()
        {
            SceneManager.LoadScene(playerHouseSceneIndex);
        }

        public void ShowRolesWindow()
        {
            rolesWindow.Show();
            buttonsPlace.gameObject.SetActive(false);
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
            buttonsPlace.SetActive(true);
            Time.timeScale = 0;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            rolesWindow.Hide();
            Time.timeScale = 1;
        }
    }
}