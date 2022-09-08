using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;
using TTRPG_Tuner.BattleEntities.Actions;
using TTRPG_Tuner.BattleProperties;
using TTRPG_Tuner;

namespace TTRPG_Tuner.Pages.Studio
{
    public partial class StudioPartialClass
    {
        public List<BaseEntity> Characters;
        public List<BaseEntity> Enemies;
        public List<BaseAction> Actions;
        public List<DamageType> DamageTypes;
        public List<StatusType> StatusTypes;
        public Dictionary<string, int> Stats;
        public StudioPartialClass()
        {
            this.DamageTypes = Defaults.GetDefaultDamageTypes();
            this.StatusTypes = Defaults.GetDefaultStatusTypes();
            this.Actions = Defaults.GetDefaultActions();
            this.Characters = Defaults.GetDefaultEntities();
            this.Enemies = Defaults.GetDefaultEntities();
            this.Stats = Defaults.GetDefaultStats();
        }
    }
}