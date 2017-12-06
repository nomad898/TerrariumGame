using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;

namespace TerrariumGame.Creators
{
    class BossCreator : Creator
    {
        public override IMovable FactoryMethod()
        {
            return new Boss();
        }
    }
}
