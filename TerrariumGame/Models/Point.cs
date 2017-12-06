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
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Point(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if (p1.XPosition != p2.XPosition || p1.YPosition != p2.YPosition)
            {
                return true;
            }
            else return false;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if (p1.XPosition == p2.XPosition && p1.YPosition == p2.YPosition)
            {
                return true;
            }
            else return false;
        }
    }
}
