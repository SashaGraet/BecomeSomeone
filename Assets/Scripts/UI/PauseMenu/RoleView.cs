using RolesSystem.Roles;
using TMPro;
using UnityEngine;

namespace UI.PauseMenu
{
    public class RoleView : MonoBehaviour
    {
        [SerializeField] private TMP_Text roleNameField;
        [SerializeField] private TMP_Text roleDescriptionField;

        public void Initialize(Role role)
        {
            roleNameField.text = role.roleName;
            roleDescriptionField.text = role.roleDescription;
        }
    }
}