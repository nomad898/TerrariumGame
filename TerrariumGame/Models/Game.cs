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
    class Game
    {
        public Map Map { get; private set; }
        private bool gameIsRunning = true;
        private const int mapHeightValue = 10;
        private const int mapWidthValue = 10;
        private const int maxHours = 24;
        private int dayCounter = 0;
        private MapManipulator mapManipulator = new MapManipulator();
        private Random random = new Random();
        private Dice dice;

        public void Run()
        {
            Map = new Map(mapHeightValue, mapWidthValue);
            mapManipulator.Init(Map);
            mapManipulator.ShowMap(Map);
            dice = new Dice(Map);
            while (gameIsRunning)
            {
                for (int hour = 0; hour < maxHours; hour++)
                {
                    Play(Map);
                    mapManipulator.SetObjects(Map);
                    mapManipulator.ShowMap(Map);
                    Thread.Sleep(1000);
                }
                dayCounter++;
                Console.WriteLine(String.Format("Day Counter:  {0}", dayCounter));
            }
        }

        ICollection<GameObject> aliveObjects = new List<GameObject>();
        ICollection<GameObject> notAliveObjects = new List<GameObject>();
        ICollection<GameObject> deletedNotAliveObjects = new List<GameObject>();

        private void MoveObjects()
        {
            foreach (var obj in Map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    dice.ChangeObjectPosition(obj);
                    aliveObjects.Add(obj);
                }
                else
                {
                    notAliveObjects.Add(obj);
                }
            }
        }
        private void CollectWork()
        {
            foreach (var alive in aliveObjects)
            {
                if (alive is Worker)
                {
                    foreach (var notAlive in notAliveObjects)
                    {
                        if (alive.Position == notAlive.Position)
                        {
                            deletedNotAliveObjects.Add(notAlive);
                        }
                        break;
                    }
                }
            }
            if (deletedNotAliveObjects.Count > 0)
            {
                foreach (var el in deletedNotAliveObjects)
                {
                    notAliveObjects.Remove(el);
                    Map.GameObjects.Remove(el);
                }
            }
        }
        private void WorkerGreetingLogic(GameObject worker, GameObject aliveObject)
        {
            if (worker is Worker && (aliveObject.Position == aliveObject.Position))
            {
                if (aliveObject is Worker)
                {
                    (worker as Worker).Talk((aliveObject as Worker));
                }
                else if (aliveObject is IManage)
                {
                    if (aliveObject is Boss)
                    {
                        (worker as Worker).Talk(aliveObject as Boss);
                    }
                    else if (aliveObject is BigBoss)
                    {
                        (worker as Worker).Talk(aliveObject as Boss);
                    }
                }
            }
        }
        private void GreetAlivePeople()
        {
            foreach (var aliveObject in aliveObjects)
            {
                foreach (var aliveO in aliveObjects)
                {
                    if (!ReferenceEquals(aliveObject, aliveO))
                    { 
                        WorkerGreetingLogic(aliveObject, aliveO);
                    }
                }
            }
        }

        private void Play(Map map)
        {
            MoveObjects();
            CollectWork();
            //  GreetAlivePeople();
        }
    }
}
