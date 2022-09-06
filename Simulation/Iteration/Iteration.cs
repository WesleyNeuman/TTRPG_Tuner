using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;
using TTRPG_Tuner.BattleSetting;

namespace TTRPG_Tuner.Simulation.Iteration
{
    public class CombatIteration
    {
        public List<BaseEntity> _characters;
        public List<BaseEntity> _enemies;
        public List<BaseEntity> _allEntities;

        public CombatIteration(Map map)
        {
            this._characters = map._characters;
            this._enemies = map._enemies;
            this._allEntities = map._characters;
        }

        public void RunCombat()
        {
            // Determine action order

            
            // Each loop through each entity


            // Determine if combat is over
        }
    }
}