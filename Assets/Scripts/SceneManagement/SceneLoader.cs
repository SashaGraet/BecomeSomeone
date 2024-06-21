using System;
using Actors.Player;
using Game;
using InventorySystem;
using ServiceLocatorSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    [RequireComponent(typeof(Collider2D))]
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneAsset loadScene;

        private Inventory _inventory;

        private void Start()
        {
            _inventory = ServiceLocator.Instance.Get<PlayerCharacter>().Inventory;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameInfo.InventoryItems = _inventory.Items;
                SceneManager.LoadScene(loadScene.name);
            }
        }
    }
}