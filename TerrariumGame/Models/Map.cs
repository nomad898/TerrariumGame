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
        #region Fields
        private char[,] matrix;

        private ICollection<GameObject> gameObjects;

        public int Height { get; private set; }
        public int Width { get; private set; }
        public char[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public ICollection<GameObject> GameObjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        public char this[int x, int y]
        {
            get
            {
                return matrix[x, y];
            }
            set
            {
                matrix[x, y] = value;
            }
        }
        #endregion

        public Map(int height, int weight)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = new List<GameObject>();
        }

        public Map(int height, int weight, ICollection<GameObject> objects)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = objects;
        }
    }
}
