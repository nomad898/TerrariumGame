using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IDice
    {
        IMap Map { get; set; }
        int Chance { get; set; }
        int Limit { get; set; }

        void ChangeObjectPosition(IMovable mvbl);
    }
}
