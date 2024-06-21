using Actors.Player;
using InventorySystem.Item;
using ServiceLocatorSystem;
using SpawnSystem;

namespace InventorySystem.Slots.Slot
{
    public class SlotPresenter
    {
        public SlotModel Model { get; }
        private readonly SlotView _view;
        private readonly Spawner _spawner;
        private readonly PlayerCharacter _player;
        
        public SlotPresenter(SlotView view, ItemType itemType)
        {
            _view = view;
            Model = new SlotModel(itemType);
            
            _player = ServiceLocator.Instance.Get<PlayerCharacter>();
            _spawner = ServiceLocator.Instance.Get<Spawner>();
            
            Model.OnChangeItem.AddListener(_view.OnItemChange);
            _view.OnItemChange(Model.ItemData ? Model.ItemData.PickUpItem.SpriteRenderer.sprite : null);
        }

        public bool IsFull()
        {
            return Model.ItemData != null;
        }

        public bool TrySetItem(ItemData item)
        {
            if (Model.Type == item.type && !IsFull())
            {
                Model.ItemData = item;
                return true;
            }

            return false;
        }

        public void CleanSlot()
        {
            PickUpItem item = _spawner.Spawn<PickUpItem>(Model.ItemData.itemPrefab, _player.transform.position);
            item.IsBlock = true;

            Model.ItemData = null;
        }
    }
}