using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Models.Alive;

namespace TerrariumGame.Models
{
    class Game
    {
        private bool gameIsRunning = true;

        public void Run()
        {
            InitGame();

            while (gameIsRunning)
            {                
                Play();
                Thread.Sleep(1000);
            }
        }


        Employee worker = new Worker(1, 1);
        Employee boss = new Boss(2, 2);
        Employee bigBoss = new BigBoss(3, 3);
        ICollection<GameObject> gameObjects;

        private void InitGame()
        {           
            gameObjects = new List<GameObject>
            {
                worker,
                boss,
                bigBoss
            };
        }

        private void Play()
        {            
            foreach (var obj in gameObjects)
            {
                Random random = new Random();
                obj.Move(new Point(random.Next(9), random.Next(9)));
            }

            Map map = new Map(10, 10, gameObjects);
            Console.Clear();
            map.ShowMap();
        }
    }
}
