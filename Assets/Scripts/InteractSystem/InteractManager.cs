using System;
using System.Collections.Generic;
using Actors.Player;
using InputSystem;
using ServiceLocatorSystem;
using UnityEngine;

namespace InteractSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractManager : MonoBehaviour
    {
        [SerializeField] private InputConfig inputConfig;

        private readonly List<InteractingEntity> _interactingEntities = new();
        private PlayerCharacter _player;
        private InteractingEntity _nearInteractingEntity;

        public void Initialize()
        {
            _player = ServiceLocator.Instance.Get<PlayerCharacter>();
        }
        
        private void Update()
        {
            if (_interactingEntities.Count > 0)
            {
                InteractingEntity newNearInteractingEntity = _interactingEntities[0];
                float minDistance = Vector2.Distance(_player.transform.position, _interactingEntities[0].transform.position);

                for (int i = 1; i < _interactingEntities.Count; i++)
                {
                    float distance = Vector2.Distance(_player.transform.position,
                        _interactingEntities[i].transform.position);
                    
                    if (distance <= minDistance)
                    {
                        minDistance = distance;
                        newNearInteractingEntity = _interactingEntities[i];
                    }
                }

                if (newNearInteractingEntity != _nearInteractingEntity)
                {
                    if (_nearInteractingEntity != null)
                    {
                        _nearInteractingEntity.HideInteractAvailable();   
                    }
                    
                    newNearInteractingEntity.ShowInteractAvailable();
                    _nearInteractingEntity = newNearInteractingEntity;
                }
            }
            else
            {
                if (_nearInteractingEntity != null)
                {
                    _nearInteractingEntity.HideInteractAvailable();
                }
                
                _nearInteractingEntity = null;
            }

            if (Input.GetKeyDown(inputConfig.interactKey) && _nearInteractingEntity != null)
            {
                _nearInteractingEntity.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interacting"))
            {
                _interactingEntities.Add(other.gameObject.GetComponent<InteractingEntity>());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interacting"))
            {
                _interactingEntities.Remove(other.gameObject.GetComponent<InteractingEntity>());
            }
        }
    }
}