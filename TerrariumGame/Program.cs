using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;

namespace TerrariumGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IMap map = new Map(10, 10);
            IFactory factory = new GameObjectFactory();
            IMapManipulator mapManipulator = new MapManipulator(map, factory);
            IDice dice = new Dice(map);
            IGame game = new Game(map, mapManipulator, dice);
            game.Start();            
            Console.ReadKey(true);
        }        
    }
}
