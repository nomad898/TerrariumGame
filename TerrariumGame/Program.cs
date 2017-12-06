using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame
{
    class Program
    {
        private static bool gameIsRunning = true;

        static void Main(string[] args)
        {
            while (gameIsRunning)
            {
                Console.Clear();
                InitGame();
                Thread.Sleep(1000);
            }
            Console.ReadKey(true);

        }

        static void InitGame()
        {
            Map world = new Map(10, 30);
            world.ShowMap();
        }
    }
}
