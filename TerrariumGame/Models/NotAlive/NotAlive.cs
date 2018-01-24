using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Models.NotAlive
{
    public abstract class NotAlive : GameObject
    {
        public override bool IsAlive
        {
            get
            {
                return false; 
            }
        }

        public NotAlive() : base()
        {
        }

        public NotAlive(int x, int y) : base(x, y)
        { }
    }
}
