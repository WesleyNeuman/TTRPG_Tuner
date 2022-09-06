using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleProperties
{
    public class DamageType
    {
        public string Name;
        public bool KnownByEnemies;

        public DamageType()
        {
            this.Name = "New Damage Type";
            this.KnownByEnemies = false;
        }
    }
}