using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;

namespace TTRPG_Tuner.Simulation.Iteration
{
    public class IterationResults
    {
        public List<BaseEntity> _characters;
        public List<BaseEntity> _enemies;

        public IterationResults(List<BaseEntity> characters, List<BaseEntity> enemies)
        {
            this._characters = characters;
            this._enemies = enemies;
        }
    }
}