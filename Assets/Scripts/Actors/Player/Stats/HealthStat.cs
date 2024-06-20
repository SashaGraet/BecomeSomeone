namespace Actors.Player.Stats
{
    public class HealthStat : PlayerStatView
    {
        protected override int GetStat()
        {
            return Player.Health;
        }
    }
}