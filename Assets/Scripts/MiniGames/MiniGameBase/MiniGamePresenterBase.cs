namespace MiniGames.MiniGameBase
{
    public abstract class MiniGamePresenterBase
    {
        protected MiniGameModelBase Model { get; private set; }
        protected MiniGameViewBase View { get; private set; }

        protected MiniGamePresenterBase(MiniGameModelBase model, MiniGameViewBase view)
        {
            Model = model;
            View = view;
        }
        
        public abstract void StartGame();
    }
}