using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IEmployee : IGameObject
    {
        decimal Salary { get; set; }
        string Name { get; set; }
        bool Mood { get; set; }
        string Talk(IEmployee ee);
    }
}
