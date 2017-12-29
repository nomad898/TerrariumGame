using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class Dice : IDice
    {
        #region Fields
        Random random;
        private readonly IMap map;
        private int chance = 100;
        private int limit = 50;

        public IMap Map
        {
            get
            {
                return map;
            }
        }
        public int Chance
        {
            get
            {
                return chance;
            }
            set
            {
                chance = value;
            }
        }
        public int Limit
        {
            get
            {
                return limit;
            }
            set
            {
                limit = value;
            }
        }
        #endregion

        public Dice(IMap map)
        {
            this.map = map;
            random = new Random();
        }

        /// <summary>
        ///     Randomly change the position of the object
        /// </summary>
        /// <param name="mvbl">IMovable object</param>
        public void ChangeObjectPosition(IMovable mvbl)
        {
            if (random.Next(chance) > limit)
            {
                ChangeObjectPositionY(mvbl);
            }
            else
            {
                ChangeObjectPositionX(mvbl);
            }
        }

        #region private methods
        /// <summary>
        ///     Change object's X postion
        /// </summary>
        /// <param name="mvbl">IMovable object</param>
        private void ChangeObjectPositionX(IMovable mvbl)
        {
            int newX, newY;
            if (random.Next(chance) > limit)
            {
                newX = mvbl.Position.X + 1;
                newY = mvbl.Position.Y;
                if ((newX > 0 && newX < map.Height)
                    && (newY > 0 && newY < map.Width))
                    mvbl.Move(new Point(newX, newY));
            }
            else
            {
                newX = mvbl.Position.X - 1;
                newY = mvbl.Position.Y;
                if ((newX > 0 && newX < map.Height)
              && (newY > 0 && newY < map.Width))
                    mvbl.Move(new Point(newX, newY));
            }
        }

        /// <summary>
        ///     Change object's Y postion
        /// </summary>
        /// <param name="mvbl">IMovable object</param>
        private void ChangeObjectPositionY(IMovable mvbl)
        {
            int newX, newY;
            if (random.Next(chance) > limit)
            {
                newX = mvbl.Position.X;
                newY = mvbl.Position.Y + 1;
                if ((newX > 0 && newX < map.Height)
                    && (newY > 0 && newY < map.Width))
                    mvbl.Move(new Point(newX, newY));
            }
            else
            {
                newX = mvbl.Position.X;
                newY = mvbl.Position.Y - 1;
                if ((newX > 0 && newX < map.Height)
              && (newY > 0 && newY < map.Width))
                    mvbl.Move(new Point(newX, newY));
            }
        }
        #endregion

    }
}
