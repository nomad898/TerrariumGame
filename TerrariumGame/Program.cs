using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Map world = new Map(10, 30);
            world.ShowMap();
            Console.ReadKey(true);

        }
    }
}
