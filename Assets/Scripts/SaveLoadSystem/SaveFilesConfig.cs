using UnityEngine;

namespace SaveLoadSystem
{
    [CreateAssetMenu(fileName = "NewSaveFilesConfig", menuName = "Game/Configs/SaveFilesConfig")]
    public class SaveFilesConfig : ScriptableObject
    {
        public string saveRolesFile;
        public string saveSettingsFile;
        public string saveDayFile;
    }
}