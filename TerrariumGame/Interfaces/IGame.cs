using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IGame
    {
        bool GameIsRunning { get; set; }

        IMap Map { get; }
        IMapManipulator MapManipulator { get; }
        IDice Dice { get; }       

        void Start();
    }
}
