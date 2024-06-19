using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "NewInventoryConfig", menuName = "Game/Configs/InventoryConfig")]
    public class InventoryConfig : ScriptableObject
    {
        /// <summary>
        /// Время на которое блокируется подьъем объекта после его выкидывания из инвентаря
        /// </summary>
        [Range(0.5f, 5f)] public float blockPickUpTime;
    }
}