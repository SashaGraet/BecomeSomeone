using System;

namespace RolesSystem.Roles
{
    [Serializable]
    public abstract class Role
    {
        public string roleName;
        public string roleDescription;

        public abstract void ApplyBonus();
    }
}