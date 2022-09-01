using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.BattleSetting
{
    public class Tile
    {
        public int _x;
        public int _y;
        public Tile(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
    }
}