using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Interfaces;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Models
{
    // TO DO Переписать
    class Game
    {
        private bool gameIsRunning = true;
        MapManipulator mapManipulator = new MapManipulator();
        private int mapHeightValue = 30;
        private int mapWidthValue = 30;

        public void Run()
        {
            Map map = new Map(mapHeightValue, mapWidthValue);
            mapManipulator.Init(map);
            mapManipulator.ShowMap(map);
            while (gameIsRunning)
            {
                Play(map);
                Thread.Sleep(1000);
            }
        }       

        private void Play(Map map)
        {
            Random random = new Random();
            foreach (var obj in map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    obj.Move(new Point(random.Next(map.Height),
                        random.Next(map.Width)));
                }
            }       
            mapManipulator.SetObjects(map);
            mapManipulator.ShowMap(map);
        }
    }
}
