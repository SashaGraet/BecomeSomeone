using Game;

namespace Actors.Player.Stats
{
    public class HealthStat : PlayerStatView
    {
        protected override int GetStat()
        {
            return GameInfo.PlayerInfo.health;
        }
    }
}