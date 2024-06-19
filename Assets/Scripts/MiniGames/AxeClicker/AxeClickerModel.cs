using MiniGames.MiniGameBase;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.AxeClicker
{
    public class AxeClickerModel : MiniGameModelBase
    {
        public GameObject Hole { get; set; }
        public int CurrentIteration = 0;

        public AxeClickerModel(MiniGameData data) : base(data)
        {
        }
    }
}