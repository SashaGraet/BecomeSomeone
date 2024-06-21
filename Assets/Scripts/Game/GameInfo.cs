using System.Collections.Generic;
using Actors.Player;
using InventorySystem.Item;

namespace Game
{
    public static class GameInfo
    {
        public static bool IsInitialized = false;
        public static PlayerInfo PlayerInfo;
        public static List<ItemData> InventoryItems = new();
        public static float Time;

        public static void Reset()
        {
            IsInitialized = false;
            PlayerInfo = null;
            InventoryItems = new();
        }
    }
}