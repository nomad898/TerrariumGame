using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame.Interfaces
{
    interface IMovable
    {
        char Icon { get; }

        bool IsAlive { get; }

        void Move(Point p);
    }
}
