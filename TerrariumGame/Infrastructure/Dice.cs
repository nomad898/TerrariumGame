using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class Dice
    {
        Random random = new Random();
        private Map map;
        private int chance = 100;
        private int limit = 50;

        public Dice(Map map)
        {
            this.map = map;
        }
      
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


        //private void ChangeObjectPositionY(IMovable mvbl)
        //{
        //    int newX, newY;
        //    if (random.Next(chance) >= limit)
        //    {
        //        if (random.Next(chance) >= limit)
        //        {
        //            newX = mvbl.Position.X + 1;
        //            newY = mvbl.Position.Y + 1;
        //            if ((newX > 0 && newX < map.Height)
        //                && (newY > 0 && newY < map.Width))
        //                mvbl.Move(new Point(newX, newY));
        //        }
        //        else
        //        {
        //            newX = mvbl.Position.X + 1;
        //            newY = mvbl.Position.Y - 1;
        //            if ((newX > 0 && newX < map.Height)
        //          && (newY > 0 && newY < map.Width))
        //                mvbl.Move(new Point(newX, newY));
        //        }
        //    }
        //}

        //private void ChangeObjectPositionX(IMovable mvbl)
        //{
        //    int newX, newY;
        //    if (random.Next(chance) >= limit)
        //    {
        //        newX = mvbl.Position.X - 1;
        //        newY = mvbl.Position.Y - 1;
        //        if ((newX > 0 && newX < map.Height)
        //           && (newY > 0 && newY < map.Width))
        //            mvbl.Move(new Point(newX, newY));
        //    }
        //    else
        //    {
        //        newX = mvbl.Position.X - 1;
        //        newY = mvbl.Position.Y + 1;
        //        if ((newX > 0 && newX < map.Height)
        //            && (newY > 0 && newY < map.Width))
        //            mvbl.Move(new Point(newX, newY));
        //    }
        //}
    }
}
