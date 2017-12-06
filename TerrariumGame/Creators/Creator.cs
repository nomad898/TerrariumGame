using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Interfaces;

namespace TerrariumGame.Creators
{
    abstract class Creator
    {
        public abstract IMovable FactoryMethod();
    }
}
