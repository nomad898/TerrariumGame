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

        private char[,] matrix;

        public Map(int height, int weight)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            FillMap();
        }

        public void ShowMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    Console.Write(matrix[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void FillMap()
        {
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    matrix[x, y] = '.';
                }
                Console.WriteLine();
            }
        }
    }
}
