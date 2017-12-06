using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class Wall : GameObject
    {
        public override char Icon { get { return 'n'; } }
 
        public override bool IsAlive
        {
            get
            {
                return false;
            }
        }

        public override void Move(Point p)
        {
            Console.WriteLine("Я стена");
        }        
    }
}
