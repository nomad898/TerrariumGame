﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.UtilityModels
{
    public struct Point
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
            if (!(obj is Point))
            {
                return false;
            }
            return Equals((Point)obj);
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
