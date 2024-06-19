using InventorySystem.Item;
using Player;
using ServiceLocatorSystem;
using SpawnSystem;

namespace InventorySystem.Slots.Slot
{
    public class SlotPresenter
    {
        private readonly SlotModel _model;
        private readonly SlotView _view;
        private readonly Spawner _spawner;
        private readonly PlayerCharacter _player;
        
        public SlotPresenter(SlotView view, ItemType itemType)
        {
            _view = view;
            _model = new SlotModel(itemType);
            
            _player = ServiceLocator.Instance.Get<PlayerCharacter>();
            _spawner = ServiceLocator.Instance.Get<Spawner>();
            
            _model.OnChangeItem.AddListener(_view.OnItemChange);
            _view.OnItemChange(_model.ItemData ? _model.ItemData.PickUpItem.SpriteRenderer.sprite : null);
        }

        public bool IsFull()
        {
            return _model.ItemData != null;
        }

        public bool TrySetItem(ItemData item)
        {
            if (_model.Type == item.type && !IsFull())
            {
                _model.ItemData = item;
                return true;
            }

            return false;
        }

        public void CleanSlot()
        {
            PickUpItem item = _spawner.Spawn<PickUpItem>(_model.ItemData.itemPrefab, _player.transform.position);
            item.IsBlock = true;

            _model.ItemData = null;
        }
    }
}