using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IEmployee : IGameObject
    {
        decimal Salary { get; set; }
        string Name { get; set; }
        bool Mood { get; set; }
        string Talk(IEmployee ee);
    }
}
