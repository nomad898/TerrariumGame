using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class Work : IMovable
    {
        public Point Position { get; set; }

        public bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public void Move(Point p)
        {
            Position = p;
        }
    }
}
