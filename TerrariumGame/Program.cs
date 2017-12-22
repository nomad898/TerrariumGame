using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;

namespace TerrariumGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();            
            Console.ReadKey(true);
        }        
    }
}
