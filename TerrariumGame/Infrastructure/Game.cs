using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Infrastructure
{
    class Game
    {
        #region Fields
        public Map Map { get; private set; }
        private bool gameIsRunning = true;
        private const int mapHeightValue = 10;
        private const int mapWidthValue = 10;

        /// <summary>
        ///  Hour duration
        /// </summary>
        private const int minutesInHour = 30;

        private MapManipulator mapManipulator = new MapManipulator();
        private Random random = new Random();
        private Dice dice;
        #endregion

        /// <summary>
        /// Start game
        /// </summary>
        public void Start()
        {
            Map = new Map(mapHeightValue, mapWidthValue);
            mapManipulator.Init(Map);
            mapManipulator.ShowMap(Map);
            dice = new Dice(Map);
            while (gameIsRunning)
            {
                for (int minute = 0; minute < minutesInHour; minute++)
                {
                    StartLogic();
                    mapManipulator.SetObjects(Map);
                    mapManipulator.ShowMap(Map);
                    Thread.Sleep(1000);
                }
                mapManipulator.HourCounter++;
                Console.Clear();

                if (mapManipulator.HourCounter == mapManipulator.MaxHour)
                {
                    gameIsRunning = false;
                }

                CreateNewWork();
            }
        }

        private void StartLogic()
        {
            int mapObjectsCount = Map.GameObjects.Count;
            for (int gameObjectIndex = 0; gameObjectIndex < mapObjectsCount; gameObjectIndex++)
            {
                var gameObject = Map.GameObjects[gameObjectIndex];
                if (gameObject.IsAlive)
                {
                    MoveObjects(gameObject);

                    if (gameObject is Employee)
                    {
                        GreetAlivePeople(gameObject);

                        var worker = gameObject as Worker;
                        if (worker != null)
                        {
                            StartWork(worker);
                        }
                    }

                }
            }
        }

        #region MovementLogic
        /// <summary>
        /// If object's IsAlive is True, change object position
        /// and add it to aliveObjects list.
        /// Or IsAlive is False, add it to notAliveObjects list.
        /// </summary>
        private void MoveObjects(GameObject gameObject)
        {
            dice.ChangeObjectPosition(gameObject);
        }

        #endregion

        #region WorkingLogic
        /// <summary>
        ///     If Object is Worker, call CollectWork() method 
        /// </summary>
        private void StartWork(Worker worker)
        {
            CollectWork(worker as Worker);
            CollectionClear();
        }

        /// <summary>
        ///     If Worker position equals work object, collect work.
        /// </summary>
        /// <param name="worker">Worker class instance</param>
        private void CollectWork(Worker worker)
        {
            foreach (var notAlive in Map.GameObjects)
            {
                if (!notAlive.IsAlive
                    && worker.Position == notAlive.Position)
                {
                    if (notAlive is Work)
                    {
                        (worker as Worker).DoWork(notAlive as Work);
                    }

                   
                }
            }
        }

        private void CollectWork(Worker worker, Work work)
        {
            if (worker.Position == work.Position)
            {
                worker.DoWork(work);
            }
        }

        private void CollectionClear()
        {
            (Map.GameObjects as List<GameObject>)
                .RemoveAll(gameObject => gameObject.State == State.Deleted);
        }

        /// <summary>
        /// Customers create new Work object to the Map
        /// </summary>
        private void CreateNewWork()
        {
            int mapObjectsCount = Map.GameObjects.Count;
            for (int obj = 0; obj < mapObjectsCount; obj++)
            {
                if (Map.GameObjects[obj] is Customer)
                {
                    var newWork = (Map.GameObjects[obj] as Customer)
                        .CreateWork();
                    Map.GameObjects.Add(newWork);
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
                (worker as Worker).Talk((aliveObject));
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
            Console.Clear();
            if (boss is BigBoss)
            {
                (boss as BigBoss).Talk((aliveObject));
            }
            else if (boss is Boss)
            {
                (boss as Boss).Talk((aliveObject));
            }
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        ///     If two alive employees have same position, call methods 
        /// </summary>        
        private void GreetAlivePeople(Employee firstAliveObject, Employee secondAliveObject)
        {
            if (firstAliveObject != secondAliveObject
                && (firstAliveObject.Position == secondAliveObject.Position)
                && secondAliveObject is Employee)
            {
                if (firstAliveObject is Worker)
                {
                    WorkerGreetingLogic(firstAliveObject as Worker, secondAliveObject as Employee);
                }
                else if (firstAliveObject is Boss)
                {
                    BossGreetingLogic(firstAliveObject as Boss, secondAliveObject as Employee);
                }
            }
        }
        #endregion        

        private void AliveObjectActions(Employee employee)
        {
            foreach (var gameObject in Map.GameObjects)
            {
                var empl = gameObject as Employee;

                if (empl != null)
                {
                    GreetAlivePeople(employee, empl);
                }

                var worker = employee as Worker;
                var work = gameObject as Work;
                if (worker != null && work != null)
                {
                    CollectWork(worker, work);
                    break;
                }
            }
        }
    }
}
