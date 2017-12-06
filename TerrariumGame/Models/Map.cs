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
        private char[,] matrix;
        private ICollection<GameObject> gameObjects;

        public int Height { get; private set; }
        public int Width { get; private set; }
        public ICollection<GameObject> GameObjects { get { return gameObjects; } }

        public Map(int height, int weight)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = new List<GameObject>();
            FillMap();
        }

        public Map(int height, int weight, ICollection<GameObject> objects)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = objects;
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
            foreach (var obj in GameObjects)
            {
                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                matrix[obj.Position.X, obj.Position.Y] = obj.Icon;               
            }
        }
    }
}
