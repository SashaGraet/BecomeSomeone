using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CustomButton : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField, Range(0, 1)] private float customAlphaHit;

        private void Awake()
        {
            image.alphaHitTestMinimumThreshold = customAlphaHit;
        }
    }
}