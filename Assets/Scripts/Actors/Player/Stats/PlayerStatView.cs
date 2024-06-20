using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Actors.Player.Stats
{
    public abstract class PlayerStatView : MonoBehaviour
    {
        [SerializeField] private GameObject objectPrefab;
        [SerializeField] private RectTransform parentRectTransform;
        
        protected PlayerCharacter Player;
        
        private readonly List<GameObject> _spawnedObjects = new();

        public void Initialize()
        {
            Player = ServiceLocator.Instance.Get<PlayerCharacter>();
            UpdateStat();
        }

        public void UpdateStat()
        {
            foreach (var obj in _spawnedObjects)
            {
                Destroy(obj);
            }

            for (int i = 0; i < GetStat(); i++)
            {
                _spawnedObjects.Add(Instantiate(objectPrefab, transform));
            }
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(parentRectTransform);
        }

        protected abstract int GetStat();
    }
}