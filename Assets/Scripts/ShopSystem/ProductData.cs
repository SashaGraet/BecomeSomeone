using System;
using InventorySystem.Item;
using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "NewProduct", menuName = "Game/Product")]
    public class ProductData : ScriptableObject
    {
        [Range(1, 5)] public int cost;
        public ItemData item;

        private void OnValidate()
        {
            if (item != null && item.type != ItemType.Tool)
            {
                item = null;
                Debug.LogError("Item is not instrument");
            }
        }
    }
}