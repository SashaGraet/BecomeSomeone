using System;
using InputSystem;
using InteractSystem;
using ServiceLocatorSystem;
using ShopSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.Trader
{
    public class TraderBehaviour : InteractingEntity
    {
        [SerializeField] private TMP_Text interactKeyField;
        [SerializeField] private InputConfig inputConfig;

        private ShopWindow shopWindow;

        private void Awake()
        {
            interactKeyField.text = inputConfig.interactKey.ToString();
            interactKeyField.gameObject.SetActive(false);
        }

        private void Start()
        {
            shopWindow = ServiceLocator.Instance.Get<ShopWindow>();
        }

        public override void Interact()
        {
            shopWindow.Show();
        }

        public override void ShowInteractAvailable()
        {
            interactKeyField.gameObject.SetActive(true);
        }

        public override void HideInteractAvailable()
        {
            interactKeyField.gameObject.SetActive(false);
        }
    }
}