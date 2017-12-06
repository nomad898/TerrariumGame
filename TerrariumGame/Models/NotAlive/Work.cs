using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Models.NotAlive
{
    class Work : GameObject
    {      
        public override bool IsAlive
        {
            get
            {
                return false;
            }
        }
       
        public override char Icon { get { return 'w'; } }         
    }
}
