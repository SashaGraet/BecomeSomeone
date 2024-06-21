using System;
using Actors.Player;
using Game;
using InventorySystem;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private TMP_Text costField;
        [SerializeField] private TMP_Text productNameField;
        [SerializeField] private Image image;

        private ProductData _product;
        private PlayerCharacter _player;

        private void Start()
        {
            _player = ServiceLocator.Instance.Get<PlayerCharacter>();
        }

        public void Initialize(ProductData productData)
        {
            costField.text = productData.cost.ToString();
            productNameField.text = productData.item.itemName;
            image.sprite = productData.item.PickUpItem.SpriteRenderer.sprite;
            _product = productData;
        }

        public void OnBuy()
        {
            if (GameInfo.PlayerInfo.coins >= _product.cost)
            {
                _player.ChangeCoins(-_product.cost);
                if ( !_player.Inventory.TryAddItem(_product.item))
                {
                    Instantiate(_product.item.itemPrefab);
                }
            }
        }
    }
}