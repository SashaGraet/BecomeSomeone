using System;
using Actors.Player;
using InventorySystem;
using InventorySystem.Item;
using RolesSystem;
using RolesSystem.Roles;
using ServiceLocatorSystem;
using UnityEngine;

namespace MiniGames
{
    public abstract class MiniGameBase : MonoBehaviour
    {
        [SerializeField] protected ItemData instrumentToStart;
        
        protected abstract Role Role { get; }
        protected bool IsActive;
        
        private RolesManager _rolesManager;
        private Inventory _inventory;

        protected virtual void OnValidate()
        {
            if (instrumentToStart != null && instrumentToStart.type != ItemType.Tool)
            {
                instrumentToStart = null;
                Debug.LogError("Item is not instrument");
            }
        }

        public abstract void StartGame();

        protected virtual void OnWin<T>(T newRole) where T : Role
        {
            _rolesManager.ActivateRole(newRole);
        }
        
        public virtual void Initialize()
        {
            _rolesManager = ServiceLocator.Instance.Get<RolesManager>();
            _inventory = ServiceLocator.Instance.Get<PlayerCharacter>().Inventory;
        }

        protected void InitializeRole()
        {
            _rolesManager.Roles.Add(Role);
        }
        
        protected bool IsAvailableToStart()
        {
            if (!IsRoleAlreadyActivated() && _inventory.IsHaveItem(instrumentToStart))
            {
                return true;
            }

            return false;
        }

        private bool IsRoleAlreadyActivated()
        {
            if (_rolesManager.GetActiveRoles().Contains(Role))
            {
                return true;
            }
            
            return false;
        }
    }
}