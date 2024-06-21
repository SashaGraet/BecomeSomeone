using System;
using System.Collections.Generic;
using Game;
using InventorySystem.Item;
using InventorySystem.Slots.Slot;
using ServiceLocatorSystem;
using UnityEngine;
namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<SlotView> slots;
        [SerializeField] private CircleCollider2D circleCollider;
        [SerializeField, Range(0.1f, 1)] private float pickUpRadius;
        
        [field: SerializeField] public InventoryConfig Config { get; private set; }

        public List<ItemData> Items
        {
            get
            {
                List<ItemData> itemsData = new();
                
                foreach (var slot in slots)
                {
                    ItemData itemData = slot.Presenter.Model.ItemData;
                    if (itemData != null)
                    {
                        itemsData.Add(itemData);   
                    }
                }

                return itemsData;
            }
        }

        private readonly List<PickUpItem> _availableItems = new();
        
        private void OnValidate()
        {
            circleCollider.radius = pickUpRadius;
        }

        public void Initialize()
        {
            foreach (var slot in slots)
            {
                slot.Initialize();
            }

            foreach (var item in GameInfo.InventoryItems)
            {
                TryAddItem(item);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GetPickUpComponent(other, item =>  _availableItems.Add(item));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            GetPickUpComponent(other, item => _availableItems.Remove(item));
        }

        private void Update()
        {
            PickUpItems();
        }
        
        public bool TryAddItem(ItemData item)
        {
            foreach (var slot in slots)
            {
                if (slot.Presenter.TrySetItem(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHaveItem(ItemData item)
        {
            foreach (var otherItem in Items)
            {
                if (otherItem == item)
                {
                    return true;
                }
            }

            return false;
        }

        private void GetPickUpComponent(Collider2D other, Action<PickUpItem> action)
        {
            if (other.CompareTag("Item"))
            {
                PickUpItem item = other.GetComponent<PickUpItem>();

                if (item != null)
                {
                    action.Invoke(item);
                }
            }
        }

        private void PickUpItems()
        {
            for (int i = _availableItems.Count - 1; i >= 0; i--)
            {
                if (!_availableItems[i].IsBlock && TryAddItem(_availableItems[i].ItemData))
                {
                    Destroy(_availableItems[i].gameObject);
                }
            }
        }
    }
}