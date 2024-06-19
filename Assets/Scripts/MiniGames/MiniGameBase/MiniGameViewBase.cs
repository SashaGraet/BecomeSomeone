using UnityEngine;

namespace MiniGames.MiniGameBase
{
    public abstract class MiniGameViewBase : MonoBehaviour
    {
        [SerializeField] protected MiniGameData data; 
        public MiniGamePresenterBase Presenter{ get; private set; }

        protected T CreatePresenter<T>(T presenter) where T : MiniGamePresenterBase
        {
            Presenter = presenter;
            return presenter;
        }

        public virtual void Initialize()
        {
            
        }
    }
}