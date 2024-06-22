using System;
using System.Collections.Generic;
using SaveLoadSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private List<Resolution> resolutions;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private SaveFilesConfig saveFilesConfig;
        [SerializeField] private Toggle toggle;
        [SerializeField] private MainMenuView mainMenu;

        private Settings _settings;
        
        private void Awake()
        {
            gameObject.SetActive(false);
            dropdown.options = new List<TMP_Dropdown.OptionData>();

            foreach (var resolution in resolutions)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}"));
            }
            
            LoadSettings();
        }

        public void OnChangeAudioEnabled(Boolean isEnable)
        {
            AudioListener.volume = isEnable ? 1 : 0;
            _settings.audioIsEnabled = isEnable;
            SaveSettings();
        }

        public void OnChangeResolution(int resolutionNumber)
        {
            Screen.SetResolution(resolutions[resolutionNumber].width, resolutions[resolutionNumber].height,
                resolutions[resolutionNumber].isFullScreen);
            _settings.resolution = resolutions[resolutionNumber];
            SaveSettings();
        }

        private void SaveSettings()
        {
            JsonSaveService saveService = new JsonSaveService();
            saveService.Save(_settings, saveFilesConfig.saveSettingsFile);
        }

        private void LoadSettings()
        {
            JsonSaveService saveService = new JsonSaveService();
            _settings = saveService.Load<Settings>(saveFilesConfig.saveSettingsFile);
            
            if (_settings == null)
            {
                InitializeSettings();
            }

            if (_settings != null)
            {
                for (int i = 0; i < resolutions.Count; i++)
                {
                    if (_settings!.resolution.IsEqual(resolutions[i]))
                    {
                        dropdown.value = i;
                    }
                }

                toggle.isOn = _settings.audioIsEnabled;
            }
        }

        private void InitializeSettings()
        {
            _settings = new Settings
            {
                audioIsEnabled = toggle.isOn,
                resolution = resolutions[0]
            };
            SaveSettings();
        }

        public void CloseSettings()
        {
            gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }
}