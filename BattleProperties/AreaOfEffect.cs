using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleProperties
{
    public class AreaOfEffect
    {
        public int Size { get; set; }
        public AoeType AoeType;
    }

    public enum AoeType
    {
        SingleTile,
        Cross,
        Cone,
        Circle,
        Box
    }
}