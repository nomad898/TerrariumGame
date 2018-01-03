using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Infrastructure.Factory
{
    class GameObjectFactory : IGameObjectFactory
    {
        // Dunno how to name it
        #region Fields
        #region Public
        public int IdBegin
        {
            get
            {
                return idBegin;
            }
        }
        public int IdEnd
        {
            get
            {
                return idEnd;
            }
        }
        #endregion
        #region Private
        private readonly int idBegin;
        private readonly int idEnd;
        #endregion
        #endregion
        public GameObjectFactory(int begin, int end)
        {
            idBegin = begin;
            idEnd = end;
        }

        /// <summary>
        ///     Create new GameObject
        /// </summary>
        /// <param name="id">object's id</param>
        /// <returns>new GameObject instance</returns>
        public IGameObject Create(int id)
        {
            switch (id)
            {
                case 1:
                    return new Worker();
                case 2:
                    return new Boss();
                case 3:
                    return new BigBoss();
                case 4:
                    return new Work();
                case 5:
                    return new Customer();
                default:
                    return null;
            }
        }

        /// <summary>
        ///     Create new GameObject
        /// </summary>
        /// <param name="id">object's id</param>
        /// <param name="x">object's X position</param>
        /// <param name="y">object's Y position</param>
        /// <returns>new GameObject instance</returns>
        public IGameObject Create(int id, int x, int y)
        {
            switch (id)
            {
                case 1:
                    return new Worker(x, y);
                case 2:
                    return new Boss(x, y);
                case 3:
                    return new BigBoss(x, y);
                case 4:
                    return new Work(x, y);
                case 5:
                    return new Customer(x, y);
                default:
                    return null;
            }
        }

        /// <summary>
        ///     Create new GameObject
        /// </summary>
        /// <param name="id">object's id</param>
        /// <param name="name">object's Name</param>
        /// <param name="x">object's X position</param>
        /// <param name="y">object's Y position</param>
        /// <returns>new GameObject instance</returns>
        public IGameObject Create(int id, string name, int x, int y)
        {
            switch (id)
            {
                case 1:
                    return new Worker(name, x, y);
                case 2:
                    return new Boss(name, x, y);
                case 3:
                    return new BigBoss(name, x, y);
                case 4:
                    return new Work(x, y);
                case 5:
                    return new Customer(x, y);
                default:
                    return null;
            }
        }
    }
}
