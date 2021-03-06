﻿using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    public class Map : IMap
    {
        #region Fields
        private char[,] matrix;
        private IGameObjectsList gameObjects;
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

        public IGameObjectsList GameObjects
        {
            get
            {
                return gameObjects;
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
        public Map(IGameObjectsList objects)
        {
            this.Width = Config.MAP_WIDTH;
            this.Height = Config.MAP_HEIGHT;
            matrix = new char[Height, Width];
            gameObjects = objects;
        }

        public Map(int height, int weight)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = new GameObjectsList();
        }

        public Map(int height, int weight, IGameObjectsList objects)
        {
            this.Width = weight;
            this.Height = height;
            matrix = new char[Height, Width];
            gameObjects = objects;
        }
        #endregion
    }
}
