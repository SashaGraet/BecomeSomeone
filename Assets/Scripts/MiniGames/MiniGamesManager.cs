using System.Collections.Generic;
using MiniGames.MiniGameBase;
using ServiceLocatorSystem;
using UnityEngine;

namespace MiniGames
{
    public class MiniGamesManager : MonoBehaviour, IService
    {
        [SerializeField] private List<MiniGameViewBase> miniGames;
        
        public void Initialize()
        {
            foreach (var miniGame in miniGames)
            {
                miniGame.Initialize();
            }
        }
        
        public void StartGame<T>() where T : MiniGameViewBase
        {
            foreach (var miniGame in miniGames)
            {
                if (typeof(T) == miniGame.GetType())
                {
                    miniGame.Presenter.StartGame();
                }
            }
        }
    }
}