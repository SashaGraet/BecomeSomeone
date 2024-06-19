using UnityEngine;

namespace MiniGames
{
    [CreateAssetMenu(fileName = "NewMiniGame", menuName = "Game/MiniGame")]
    public class MiniGameData : ScriptableObject
    {
        public RoleData rewardRole;
    }
}