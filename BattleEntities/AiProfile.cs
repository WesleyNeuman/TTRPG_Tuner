using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleEntities
{
    public class AiProfile
    {
        public int _attacker;
        public int _healer;
        public int _disabler;
        public int _finisher;
        public int _selfInterest;

        public AiProfile(int attacker, int healer, int disabler, int finisher, int selfInterest)
        {
            this._attacker = attacker;
            this._healer = healer;
            this._disabler = disabler;
            this._finisher = finisher;
            this._selfInterest = selfInterest;
        }
    }
}