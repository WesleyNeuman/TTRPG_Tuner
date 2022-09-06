using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleSetting;
using TTRPG_Tuner.Simulation.Iteration;

namespace TTRPG_Tuner.Simulation
{
    public class Simulation
    {
        public Map _map;
        public int _iterations;

        public Simulation(Map map, int iterations)
        {
            this._map = map;
            this._iterations = iterations;
        }

        public IterationResults PerformIteration(Map map)
        {
            CombatIteration iteration = new CombatIteration(map);

            return new IterationResults(iteration._characters, iteration._enemies);
        }
    }
}