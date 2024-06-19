using UnityEngine;

namespace MiniGames
{
    [CreateAssetMenu(fileName = "NewRole", menuName = "Game/Role")]
    public class RoleData : ScriptableObject
    {
        public string roleName;
        public string roleDescription;
    }
}