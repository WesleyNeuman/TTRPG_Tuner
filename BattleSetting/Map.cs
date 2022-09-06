using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;

namespace TTRPG_Tuner.BattleSetting
{
    public class Map
    {
        public int _x;
        public int _y;
        public Tile[,] _tiles;
        public List<BaseEntity> _characters;
        public List<BaseEntity> _enemies;

        public Map(int x, int y)
        {
            this._x = x;
            this._y = y;
            this._tiles = new Tile[x,y];
            this._characters = new List<BaseEntity>();
            this._enemies = new List<BaseEntity>();
        }

        public void GenerateFreshMap()
        {
            for (int i = 0; i < this._x; i++)
            {
                for (int j = 0; j < this._y; j++)
                {
                    this._tiles[i,j] = new Tile(i,j);
                }
            }
        }
    }
}