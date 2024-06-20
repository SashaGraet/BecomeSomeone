using System;
using UnityEngine;

namespace UI.MainMenu
{
    [Serializable]
    public class Resolution
    {
        [Range(500, 5000)] public int width;
        [Range(500, 5000)] public int height;
        public bool isFullScreen;

        public bool IsEqual(Resolution resolution)
        {
            if (resolution != null)
            {

                if (resolution.height == height && resolution.width == width &&
                    resolution.isFullScreen == isFullScreen) return true;
            }

            return false;
        }
    }
}