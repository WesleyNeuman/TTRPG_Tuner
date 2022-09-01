using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTRPG_Tuner.Calculations
{
    public class DiceRoll
    {
        private int _count { get; set; }
        private int _size { get; set; }
        private Random _r;
        public DiceRoll(int count, int size)
        {
            this._count = count;
            this._size = size;
            this._r = new Random();
        }

        public int Roll()
        {
            int total = 0;
            for (int i = 0; i < this._count; i++)
            {
                total += (int)(this._r.Next() * this._size);
            }
            return total;
        }
    }
}