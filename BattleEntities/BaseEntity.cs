using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleEntities
{
    public class BaseEntity
    {
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        public Dictionary<string, int> Stats = new Dictionary<string, int>();
    }
}