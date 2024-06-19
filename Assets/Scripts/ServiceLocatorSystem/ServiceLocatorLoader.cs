using System;
using System.Collections.Generic;
using InputSystem;
using InventorySystem;
using InventorySystem.Slots.Slot;
using MiniGames;
using MiniGames.AxeClicker;
using Player;
using SpawnSystem;
using UI;
using UnityEngine;

namespace ServiceLocatorSystem
{
    public class ServiceLocatorLoader : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private Spawner spawner;
        [SerializeField] private PlayerCharacter player;
        [SerializeField] private MiniGamesManager miniGamesManager;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private PauseMenu pauseMenu;
        
        private void Awake()
        {
            ServiceLocator.Initialize();
            
            AddServices();
            InitializeServices();
        }

        private void AddServices()
        {
            ServiceLocator.Instance.Add(inventory);
            ServiceLocator.Instance.Add(spawner);
            ServiceLocator.Instance.Add(player);
            ServiceLocator.Instance.Add(miniGamesManager);
            ServiceLocator.Instance.Add(inputManager);
            ServiceLocator.Instance.Add(pauseMenu);
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.Get<Inventory>().Initialize();
            ServiceLocator.Instance.Get<MiniGamesManager>().Initialize();
            ServiceLocator.Instance.Get<InputManager>().Initialize();
            
            ServiceLocator.Instance.Get<MiniGamesManager>().StartGame<AxeClickerView>();
        }
    }
}