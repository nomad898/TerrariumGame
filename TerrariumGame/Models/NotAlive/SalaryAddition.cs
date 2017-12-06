using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class SalaryAddition : IMovable
    {
        public Point Position { get; set; }

        public bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public char Icon { get { return 's'; } }

        public void Move(Point p)
        {
            Position = p;
        }
    }
}
