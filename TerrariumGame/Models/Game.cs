using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models
{
    class Game
    {
        private bool gameIsRunning = true;

        public void Run()
        {
            Map map = new Map(10, 30);
            InitGame(map);

            while (gameIsRunning)
            {
                Play(map);
                Thread.Sleep(1000);
            }
        }
        
        MapManipulator mapManipulator;

        private void InitGame(Map map)
        {           
            mapManipulator = new MapManipulator();
           
            Employee worker = new Worker(1, 1);
            Employee boss = new Boss(2, 2);
            Employee bigBoss = new BigBoss(3, 3);
            
            GameObject work = new Work(4,4);
            map.GameObjects = new List<GameObject>
            {
                worker,
                boss,
                bigBoss,
                work
            };            
        }

        private void Play(Map map)
        {
            Random random = new Random();
            foreach (var obj in map.GameObjects)
            {
                obj.Move(new Point(random.Next(9), random.Next(9)));
            }
            mapManipulator.FillMap(map);
            mapManipulator.ShowMap(map);
        }
    }
}
