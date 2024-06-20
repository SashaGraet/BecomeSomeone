using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MiniGames.AxeClicker
{
    public class Hole : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }

        [SerializeField] private Button button;
        
        public void Initialize(Action action)
        {
            button.onClick.AddListener(new UnityAction(action));
        }
    }
}