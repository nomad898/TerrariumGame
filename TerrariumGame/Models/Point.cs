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
            var temp = obj as Point?;
            if (temp == null)
            {
                return false;
            }
            return Equals(temp);           
        }

        public bool Equals(Point obj)
        {
            if (X != obj.X)
            {
                return false;
            }
            return Y == obj.Y;
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
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
    }
}
