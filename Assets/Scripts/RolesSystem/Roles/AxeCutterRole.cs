using System;
using Actors.Player;
using Newtonsoft.Json;
using ServiceLocatorSystem;
using UnityEngine;

namespace RolesSystem.Roles
{
    [Serializable]
    public class AxeCutterRole : Role
    {
        [Min(1)] public int coinsBonus;
        
        public override void ApplyBonus()
        {
            ServiceLocator.Instance.Get<PlayerCharacter>().ChangeCoins(coinsBonus);
        }
    }
}