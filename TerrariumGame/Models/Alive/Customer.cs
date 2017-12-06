using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models.Alive
{
    class Customer : GameObject, IManage
    {
        public override bool IsAlive
        {
            get
            {
                return true;
            }
        }

        public override char Icon { get { return 'C'; } }
            
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
