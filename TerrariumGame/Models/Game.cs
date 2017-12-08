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
        private int mapHeightValue = 30;
        private int mapWidthValue = 30;
        MapManipulator mapManipulator = new MapManipulator();
        ICollection<GameObject> aliveObjects = new List<GameObject>();
        ICollection<GameObject> notAliveObjects = new List<GameObject>();
   
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
                    aliveObjects.Add(obj);
                }
                else
                {
                    notAliveObjects.Add(obj);
                }
            }

            foreach (var obj in map.GameObjects)
            {
                Console.SetCursorPosition(50, 1);
                foreach (var e in aliveObjects)
                {
                    if (ReferenceEquals(obj, e))
                    {
                        continue;
                    }
                    if (obj is IManagable 
                        && e is IManage 
                        && obj.Position == e.Position)
                    {

                    }
                }
            }

            List<GameObject> toDelete = new List<GameObject>();

            foreach (var obj in map.GameObjects)
            {
                Console.SetCursorPosition(50, 10);
                foreach (var e in notAliveObjects)
                {
                    if (obj is IManagable
                        && e is Work
                        && obj.Position == e.Position)
                    {
                        toDelete.Add(e);
                    }
                }
            }
            foreach (var e in toDelete)
            {
                map.GameObjects.Remove(e);
                Console.Write("e was Removed");
                Thread.Sleep(3000);
            }

            mapManipulator.SetObjects(map);
            mapManipulator.ShowMap(map);
        }
    }
}
