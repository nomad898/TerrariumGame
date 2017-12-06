using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models
{
    class Map
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        private char[,] map;

        public Map(int height, int weight)
        {
            this.Width = ++weight;
            this.Height = ++height;
            map = new char[Height, Width];
            FillMap();
        }

        public void ShowMap()
        {
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void FillMap()
        {
            for (int x = 0; x < Height - 1; x++)
            {
                for (int y = 0; y < Width - 1; y++)
                {
                    map[x, y] = '.';
                }
                Console.WriteLine();
            }
        }
    }
}
