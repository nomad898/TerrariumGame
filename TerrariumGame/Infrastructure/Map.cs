using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class Map : IMap
    {
        #region Fields
        private char[,] matrix;
        private readonly IList<GameObject> gameObjects;
        private int height;
        private int width;
        #endregion
        #region IMap
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

        public IList<GameObject> GameObjects
        {
            get
            {
                return gameObjects;
            }
            set
            {
                gameObjects = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public char[,] Matrix
        {
            get
            {
                return matrix;
            }
            set
            {
                matrix = value;
            }
        }
         
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        #endregion
        #region Ctor
        public Map(int height, int weight)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = new List<GameObject>();
        }

        public Map(int height, int weight, IList<GameObject> objects)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = objects;
        }
        #endregion
    }
}
