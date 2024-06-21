using UnityEngine;

namespace InteractSystem
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class InteractingEntity : MonoBehaviour
    {
        public abstract void Interact();
        public abstract void ShowInteractAvailable();
        public abstract void HideInteractAvailable();
    }
}