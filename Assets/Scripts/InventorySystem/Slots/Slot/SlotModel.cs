using System;
using InventorySystem.Item;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem.Slots.Slot
{
    public class SlotModel
    {
        public UnityEvent<Sprite> OnChangeItem { get; private set; } = new();
        
        public readonly ItemType Type;
        public ItemData ItemData
        {
            get => _itemData;
            set
            {
                _itemData = value;
                OnChangeItem.Invoke(_itemData ? ItemData.PickUpItem.SpriteRenderer.sprite : null);
            }
        }

        private ItemData _itemData;

        public SlotModel(ItemType type)
        {
            Type = type;
        }
    }
}