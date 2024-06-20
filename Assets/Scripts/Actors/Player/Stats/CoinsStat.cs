namespace Actors.Player.Stats
{
    public class CoinsStat : PlayerStatView
    {
        protected override int GetStat()
        {
            return Player.Coins;
        }
    }
}