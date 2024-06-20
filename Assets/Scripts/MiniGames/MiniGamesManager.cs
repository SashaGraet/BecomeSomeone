using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;

namespace MiniGames
{
    public class MiniGamesManager : MonoBehaviour, IService
    {
        [SerializeField] private List<MiniGameBase> miniGames;
        
        public void Initialize()
        {
            foreach (var miniGame in miniGames)
            {
                miniGame.Initialize();
            }
        }
        
        public void StartGame<T>() where T : MiniGameBase
        {
            foreach (var miniGame in miniGames)
            {
                if (typeof(T) == miniGame.GetType())
                {
                    miniGame.StartGame();
                }
            }
        }
    }
}