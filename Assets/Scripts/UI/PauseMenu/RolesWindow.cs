using System;
using System.Collections.Generic;
using RolesSystem;
using ServiceLocatorSystem;
using UnityEngine;

namespace UI.PauseMenu
{
    public class RolesWindow : MonoBehaviour
    {
        [SerializeField] private GameObject rolePrefab;
        
        private RolesManager _rolesManager;
        private readonly List<GameObject> _spawnedRolesUI = new();

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Initialize()
        {
            _rolesManager = ServiceLocator.Instance.Get<RolesManager>();
            UpdateRoles();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            UpdateRoles();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void UpdateRoles()
        {
            foreach (var role in _spawnedRolesUI)
            {
                Destroy(role);
            }

            foreach (var role in _rolesManager.GetActiveRoles())
            {
                RoleView roleView = Instantiate(rolePrefab, transform).GetComponent<RoleView>();
                roleView.Initialize(role);
                _spawnedRolesUI.Add(roleView.gameObject);
            }
        }
    }
}