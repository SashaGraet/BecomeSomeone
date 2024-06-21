using System;
using System.Collections.Generic;
using Game;
using RolesSystem.Roles;
using SaveLoadSystem;
using ServiceLocatorSystem;
using UI.PauseMenu;
using UnityEngine;
using UnityEngine.Events;

namespace RolesSystem
{
    public class RolesManager : IService
    {
        public List<Role> Roles { get; } = new();
        
        private List<string> _activeRolesNames = new();
        private readonly string _filePath;

        public RolesManager(SaveFilesConfig saveFilesConfig)
        {
            _filePath = saveFilesConfig.saveRolesFile;
        }
        
        public void Initialize()
        {
            Load();
            if (!GameInfo.IsInitialized)
            {
                foreach (var role in GetActiveRoles())
                {
                    role.ApplyBonus();
                }   
            }
        }

        public void ActivateRole<T>(T role) where T : Role
        {
            if (!_activeRolesNames.Contains(role.roleName))
            {
                _activeRolesNames.Add(role.roleName);
                Save();
                role.ApplyBonus();
            }
            else
            {
                Debug.LogError($"Role {role.roleName} already exist");
            }
        }

        public List<Role> GetActiveRoles()
        {
            List<Role> activeRoles = new List<Role>();
            
            foreach (var role in Roles)
            {
                if (_activeRolesNames.Contains(role.roleName))
                {
                    activeRoles.Add(role);
                }
            }

            return activeRoles;
        }

        private void Load()
        {
            JsonSaveService saveService = new JsonSaveService();
            _activeRolesNames = saveService.Load<List<string>>(_filePath);
            if (_activeRolesNames == null)
            {
                _activeRolesNames = new List<string>();
                Save();
            }
        }

        private void Save()
        {
            JsonSaveService saveService = new JsonSaveService();
            saveService.Save(_activeRolesNames, _filePath);
        }
    }
}