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
        #region Fields
        public Map Map { get; private set; }
        private bool gameIsRunning = true;
        private const int mapHeightValue = 10;
        private const int mapWidthValue = 10;
        private const int maxHours = 24;
        private int dayCounter = 0;
        private MapManipulator mapManipulator = new MapManipulator();
        private Random random = new Random();
        private Dice dice;
        #endregion

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
                Console.Clear();
                Console.SetCursorPosition(Map.Width + 10, 0);
                Console.WriteLine(string.Format("Day Counter:  {0}", dayCounter));
                CreateNewWork();
            }
        }

        private void Play(Map map)
        {
            MoveObjects();
            CollectWork();
            GreetAlivePeople();
        }

        #region InGameObjects
        ICollection<GameObject> aliveObjects = new List<GameObject>();
        ICollection<GameObject> notAliveObjects = new List<GameObject>();
        ICollection<GameObject> deletedNotAliveObjects = new List<GameObject>();
        #endregion 

        #region MovementLogic
        private void CollectionsClear()
        {
            aliveObjects.Clear();
            notAliveObjects.Clear();
            deletedNotAliveObjects.Clear();
        }
        private void MoveObjects()
        {
            CollectionsClear();
            foreach (var obj in Map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    dice.ChangeObjectPosition(obj);
                    aliveObjects.Add(obj);
                }
                else if (!obj.IsAlive)
                {
                    notAliveObjects.Add(obj);
                }
            }
        }
        private void ClearDeletedObject()
        {
            if (deletedNotAliveObjects.Count > 0)
            {
                foreach (var el in deletedNotAliveObjects)
                {
                    Map.GameObjects.Remove(el);
                }
            }
        }
        #endregion

        #region Working
        private void CollectWork()
        {
            foreach (var worker in aliveObjects)
            {
                if (worker is Worker)
                {
                    foreach (var notAlive in notAliveObjects)
                    {
                        if (worker.Position == notAlive.Position)
                        {
                            if (notAlive is Work)
                            {
                                (worker as Worker).DoWork(notAlive as Work);
                            }
                            deletedNotAliveObjects.Add(notAlive);
                            break;
                        }
                    }
                }
            }
            ClearDeletedObject();
        }
        private void CreateNewWork()
        {
            foreach (var customer in aliveObjects)
            {
                if (customer is Customer)
                {
                    Map.GameObjects.Add((customer as Customer).CreateWork());
                }
            }
        }
        #endregion

        #region GreetingLogic
        private void WorkerGreetingLogic(Employee worker, Employee aliveObject)
        {
            if (worker is Worker)                
            {
                Console.Clear();
                if (aliveObject is Worker)
                {
                    (worker as Worker).Talk((aliveObject as Worker));
                }
                else if (aliveObject is IManage)
                {
                    (worker as Worker).Talk(aliveObject as Boss);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        private void BossGreetingLogic(Employee boss, Employee aliveObject)
        {
            if (boss is Boss)
            {
                Console.Clear();
                if (aliveObject is Worker)
                {
                    (boss as Boss).Talk((aliveObject as Worker));
                }
                else if (aliveObject is IManage)
                {
                    if (aliveObject is BigBoss)
                    {
                        (boss as Boss).Talk(aliveObject as BigBoss);
                    }
                    else if (aliveObject is Boss)
                    {
                        if (boss is BigBoss)
                        {
                            (boss as BigBoss).Talk(aliveObject as Boss);
                        }
                        else
                        {
                            (boss as Boss).Talk(aliveObject as Boss);
                        }
                    }
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private void GreetAlivePeople()
        {
            foreach (var aliveObject in aliveObjects)
            {
                foreach (var aliveO in aliveObjects)
                {
                    if (!ReferenceEquals(aliveObject, aliveO)
                        && (aliveObject.Position == aliveO.Position)
                        && aliveObject is Employee
                        && aliveO is Employee)
                    {
                        if (aliveObject is Worker)
                        {
                            WorkerGreetingLogic(aliveObject as Worker, aliveO as Employee);
                        }
                        else if (aliveObject is Boss)
                        {
                            BossGreetingLogic(aliveObject as Boss, aliveO as Employee);
                        }
                    }
                }
            }
        }

        private void Greet<T, V>(T obj1, V obj2) where T : Employee
        {
            if (obj1 is Worker)
            {
                Console.Clear();
                if (obj2 is Worker)
                {
                    (obj1 as Worker).Talk((obj2 as Worker));
                }
                else if (obj2 is IManage)
                {
                    (obj1 as Worker).Talk(obj2 as Boss);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        #endregion    
    }
}
