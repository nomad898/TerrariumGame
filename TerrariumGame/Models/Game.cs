using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariumGame.Models
{
    class Game
    {
        private bool gameIsRunning = true;

        public void Run()
        {
            while (gameIsRunning)
            {
                Console.Clear();
                InitGame();
                Thread.Sleep(1000);
            }
        }

        private void InitGame()
        {
            Map world = new Map(10, 10);
            world.ShowMap();
        }
    }
}
