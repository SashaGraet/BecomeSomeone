using RolesSystem;
using RolesSystem.Roles;
using ServiceLocatorSystem;
using UnityEngine;

namespace MiniGames
{
    public abstract class MiniGameBase : MonoBehaviour
    {
        protected abstract Role Role { get; }
        protected bool IsActive;
        
        private RolesManager _rolesManager;

        public abstract void StartGame();

        protected virtual void OnWin<T>(T newRole) where T : Role
        {
            _rolesManager.ActivateRole(newRole);
        }
        
        public virtual void Initialize()
        {
            _rolesManager = ServiceLocator.Instance.Get<RolesManager>();
        }

        protected void InitializeRole()
        {
            _rolesManager.Roles.Add(Role);
        }

        protected bool IsRoleAlreadyActivated()
        {
            if (_rolesManager.GetActiveRoles().Contains(Role))
            {
                return true;
            }
            
            return false;
        }
    }
}