using System.Collections;
using ServiceLocatorSystem;
using UnityEngine;

namespace InventorySystem.Item
{
    public class PickUpItem : MonoBehaviour
    {
        [field: SerializeField] public ItemData ItemData { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }

        private Inventory _inventory;

        public bool IsBlock
        {
            get => _isBlock;
            set
            {
                _inventory = ServiceLocator.Instance.Get<Inventory>();

                if (value)
                {
                    StartCoroutine(BlockPickUp());
                }

                _isBlock = value;
            }
        }
        private bool _isBlock;

        private IEnumerator BlockPickUp()
        {
            yield return new WaitForSeconds(_inventory.Config.blockPickUpTime);
            IsBlock = false;
        }
    }
}
