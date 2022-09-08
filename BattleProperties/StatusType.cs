using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleProperties
{
    public class StatusType
    {
        public string Name;
        public bool KnownByEnemies;
        public List<StatusComponent> StatusComponents;

        public StatusType()
        {
            this.Name = "New Status Type";
            this.KnownByEnemies = false;
            this.StatusComponents = new List<StatusComponent>();
        }
    }

    public class StatusComponent
    {
        public string Label = "Status Component";
        public int Save;
        public string? SaveStat;

    }
}