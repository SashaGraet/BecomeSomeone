using System.Collections.Generic;
using SaveLoadSystem;
using SceneManagement;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private SaveFilesConfig saveFilesConfig;
        [SerializeField] private SceneAsset playerHouseScene;
        [SerializeField] private SettingsWindow settingsWindow;
        
        public void OnNewGame()
        {
            JsonSaveService saveService = new JsonSaveService();
            
            saveService.Save(new List<string>(), saveFilesConfig.saveRolesFile);
            SceneManager.LoadScene(playerHouseScene.name);
        }

        public void OnContinueGame()
        {
            SceneManager.LoadScene(playerHouseScene.name);
        }

        public void OnSettings()
        {
            settingsWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}