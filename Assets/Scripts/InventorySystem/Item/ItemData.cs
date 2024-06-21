using UnityEngine;

namespace InventorySystem.Item
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public GameObject itemPrefab;
        public ItemType type;
        
        public PickUpItem PickUpItem { get; private set; }

        private void OnValidate()
        {
            if (itemPrefab != null)
            {
                PickUpItem pickUpItem = itemPrefab.GetComponent<PickUpItem>();
            
                if (pickUpItem == null)
                {
                    Debug.LogError("Prefab doesn't contain PickUpItem component");
                    itemPrefab = null;
                }
                else
                {
                    PickUpItem = pickUpItem;
                }   
            }
        }
    }
}