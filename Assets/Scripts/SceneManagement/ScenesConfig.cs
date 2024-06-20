using UnityEngine;

namespace SceneManagement
{
    [CreateAssetMenu(fileName = "NewScenesConfig", menuName = "Game/Configs/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public int mainMenuSceneIndex;
        public int playerHouseSceneIndex;
        public int gameSceneIndex;
        public int shopSceneIndex;
    }
}