using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces.UI
{
    public interface IUI
    {
        void ShowMap(IMap map);
        void ShowHourCounter(IMap map, int hourCounter);
    }
}
