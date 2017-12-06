using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Customer : IMovable, IManage
    {
        public bool IsAlive
        {
            get
            {
                return true;
            }
        }

        public void Move(Point p)
        {
            throw new NotImplementedException();
        }
    
        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
        }

        public Work CreateWork()
        {
            return new Work();
        }
    }
}
