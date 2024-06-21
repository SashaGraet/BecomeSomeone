using UnityEngine;

namespace InputSystem
{
    [CreateAssetMenu(fileName = "NewInputConfig", menuName = "Game/Configs/InputConfig")]
    public class InputConfig : ScriptableObject
    {
        public KeyCode pauseKey;
        public KeyCode interactKey;
    }
}