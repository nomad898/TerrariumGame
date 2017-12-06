using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class Wall : IMovable
    {
        public char Icon { get { return 'n'; } }

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
            Console.WriteLine("Я стена");
        }        
    }
}
