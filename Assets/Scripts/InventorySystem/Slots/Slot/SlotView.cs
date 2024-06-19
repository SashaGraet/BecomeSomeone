using System;
using InventorySystem.Item;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Slots.Slot
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private Image itemImage;
        [SerializeField] private Button cleanButton;

        public SlotPresenter Presenter { get; private set; }

        public void Initialize()
        {
            Presenter = new SlotPresenter(this, itemType);
            cleanButton.onClick.AddListener(Presenter.CleanSlot);
        }

        public void OnItemChange(Sprite sprite)
        {
            itemImage.color = sprite == null ? Color.clear : Color.white;
            itemImage.sprite = sprite;
        }
    }
}
