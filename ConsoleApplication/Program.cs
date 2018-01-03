using InterfaceLibrary.Interfaces;
using System;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IMap map = new Map(10, 10);
            IGameObjectFactory goFactory = new GameObjectFactory();
            IMapManipulator mapManipulator = new MapManipulator(map, goFactory, 4, 12, 1, 6);
            IDice dice = new Dice(map);
            IGame game = new Game(map, mapManipulator, dice);
            game.Start();
            Console.ReadKey(true);
        }
    }
}
