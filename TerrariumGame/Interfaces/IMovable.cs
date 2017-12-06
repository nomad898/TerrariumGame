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
        bool IsAlive { get; }

        void Move(Point p);
    }
}
