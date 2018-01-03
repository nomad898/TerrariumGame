using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IDice
    {
        IMap Map { get; }
        int Chance { get; set; }
        int Limit { get; set; }

        void ChangeObjectPosition(IMovable mvbl);
    }
}
