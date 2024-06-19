namespace MiniGames.MiniGameBase
{
    public abstract class MiniGameModelBase
    {
        public MiniGameData Data { get; private set; }

        protected MiniGameModelBase(MiniGameData data)
        {
            Data = data;
        }
    }
}