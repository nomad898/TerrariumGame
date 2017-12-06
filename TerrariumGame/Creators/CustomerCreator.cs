using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Creators
{
    class CustomerCreator : Creator
    {
        public override IMovable FactoryMethod()
        {
            return new Models.Alive.Customer();
        }
    }
}
