using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;

namespace TerrariumGame.Models
{
    struct Point
    {
        #region Fields
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((Point)obj);
        }

        public bool Equals(Point obj)
        {           
            if (GetHashCode() != obj.GetHashCode())
            {
                return false;
            }
            return ((X.Equals(obj.X)) && (Y.Equals(obj.Y)));
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + X.GetHashCode();
            hash = (hash * 7) + Y.GetHashCode();
            return hash;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y)
            {
                return true;
            }
            else return false;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if (p1.X != p2.X || p1.Y != p2.Y)
            {
                return true;
            }
            else return false;
        }
    }
}
