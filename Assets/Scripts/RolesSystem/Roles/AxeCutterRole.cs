using System;
using Actors.Player;
using Newtonsoft.Json;
using ServiceLocatorSystem;

namespace RolesSystem.Roles
{
    [Serializable]
    public class AxeCutterRole : Role
    {
        public int coinsBonus;
        
        public override void ApplyBonus()
        {
            ServiceLocator.Instance.Get<PlayerCharacter>().AddCoins(coinsBonus);
        }
    }
}