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
            GoWork();
            GreetAlivePeople();
        }

        #region InGameObjects
        /// <summary>
        /// Contains objects that have IsAlive - True
        /// </summary>
        ICollection<GameObject> aliveObjects = new List<GameObject>();

        /// <summary>
        /// Contains objects that have IsAlive - False
        /// </summary>
        ICollection<GameObject> notAliveObjects = new List<GameObject>();

        /// <summary>
        /// Contains objects that need to delete
        /// </summary>
        ICollection<GameObject> deletedNotAliveObjects = new List<GameObject>();
        #endregion 

        #region MovementLogic
        private void CollectionsClear()
        {
            aliveObjects.Clear();
            notAliveObjects.Clear();
            deletedNotAliveObjects.Clear();
        }
        
        /// <summary>
        /// If object's IsAlive is True, change object position
        /// and add it to aliveObjects list.
        /// Or IsAlive is False, add it to notAliveObjects list.
        /// </summary>
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

        #endregion

        #region WorkingLogic

        /// <summary>
        ///     If Object is Worker, call CollectWork() method 
        /// </summary>
        private void GoWork()
        {
            foreach (var worker in aliveObjects)
            {
                if (worker is Worker)
                {
                    CollectWork(worker as Worker);
                }
            }
            ClearDeletedObject();
        }

        /// <summary>
        ///     If Worker position equals work object, collect work.
        /// </summary>
        /// <param name="worker">Worker class instance</param>
        private void CollectWork(Worker worker)
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

        /// <summary>
        /// Delete useless objects
        /// </summary>
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

        /// <summary>
        /// Customers create new Work object to the Map
        /// </summary>
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
        /// <summary>
        ///     Talk with other employee.
        /// </summary>
        /// <param name="worker">Work class instance</param>
        /// <param name="aliveObject">Employee class instanse</param>
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

        /// <summary>
        ///     Talk with other employee.
        /// </summary>
        /// <param name="boss">Boss class instance</param>
        /// <param name="aliveObject">Employee class instanse</param>
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
                    BossGreetChoice(boss, aliveObject);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        /// <summary>
        ///     Helper method to BossGreetingLogic()
        /// </summary>
        /// <param name="boss">Boss class instance</param>
        /// <param name="aliveObject">Employee class instanse</param>
        private void BossGreetChoice(Employee boss, Employee aliveObject)
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

        /// <summary>
        ///     If two alive employees have same position, call methods 
        /// </summary>
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
        #endregion    
    }
}
