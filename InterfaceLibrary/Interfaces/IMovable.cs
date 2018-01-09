using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IMovable
    {
        char Icon { get; }
        Point Position { get; set; }
        void Move(Point p);
    }
}
