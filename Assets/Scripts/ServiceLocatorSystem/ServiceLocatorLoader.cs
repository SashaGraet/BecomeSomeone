using System;
using System.Collections.Generic;
using Actors.Player;
using Game;
using InputSystem;
using InventorySystem;
using InventorySystem.Slots.Slot;
using MiniGames;
using MiniGames.AxeClicker;
using RolesSystem;
using SaveLoadSystem;
using ShopSystem;
using SpawnSystem;
using UI;
using UI.PauseMenu;
using UnityEngine;
using UnityEngine.Serialization;

namespace ServiceLocatorSystem
{
    public class ServiceLocatorLoader : MonoBehaviour
    {
        [SerializeField] private Spawner spawner;
        [SerializeField] private PlayerCharacter player;
        [SerializeField] private MiniGamesManager miniGamesManager;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private PauseMenuView pauseMenuView;
        [SerializeField] private Timer timer;
        [SerializeField] private SaveFilesConfig saveFilesConfig;
        [SerializeField] private ShopWindow shopWindow;
        
        private void Awake()
        {
            ServiceLocator.Initialize();
            
            AddServices();
            InitializeServices();
        }

        private void AddServices()
        {
            ServiceLocator.Instance.Add(spawner);
            ServiceLocator.Instance.Add(player);
            ServiceLocator.Instance.Add(miniGamesManager);
            ServiceLocator.Instance.Add(inputManager);
            ServiceLocator.Instance.Add(pauseMenuView);
            ServiceLocator.Instance.Add(timer);
            ServiceLocator.Instance.Add(shopWindow);
            
            ServiceLocator.Instance.Add(new RolesManager(saveFilesConfig));
        }

        private void InitializeServices()
        {
            // Игрок инициализируется раньеш всех
            ServiceLocator.Instance.Get<PlayerCharacter>().Initialize();
            ServiceLocator.Instance.Get<InputManager>().Initialize();
            // Миниигры инициализируются до ролей
            ServiceLocator.Instance.Get<MiniGamesManager>().Initialize();
            ServiceLocator.Instance.Get<RolesManager>().Initialize();
            ServiceLocator.Instance.Get<PauseMenuView>().Initialize();
            ServiceLocator.Instance.Get<Timer>().Initialize();
            
            GameInfo.IsInitialized = true;
        }
    }
}