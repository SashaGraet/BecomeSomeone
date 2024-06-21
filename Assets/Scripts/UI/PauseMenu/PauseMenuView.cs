using System.Collections.Generic;
using Game;
using RolesSystem;
using SceneManagement;
using ServiceLocatorSystem;
using UnityEditor;
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
            Time.timeScale = 1;
            GameInfo.Reset();
            SceneManager.LoadScene(mainMenuSceneIndex);
        }

        public void RestartDay()
        {
            Time.timeScale = 1;
            GameInfo.Reset();
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