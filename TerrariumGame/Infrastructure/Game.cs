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
        #region Public
        public Map Map { get; private set; }
        #endregion
        #region Private
        private bool gameIsRunning = true;
        private const int mapHeightValue = 10;
        private const int mapWidthValue = 10;

        /// <summary>
        ///     Hour duration
        /// </summary>
        private const int minutesInHour = 30;
        private const int delayTime = 1000;

        private MapManipulator mapManipulator = new MapManipulator();
        private Random random = new Random();
        private Dice dice;
        #endregion
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
                    Thread.Sleep(delayTime);
                }
                mapManipulator.HourCounter++;

                if (mapManipulator.HourCounter == mapManipulator.MaxHour)
                {
                    gameIsRunning = false;
                }

                CreateNewWork();
            }
        }

        #region GameLogic
        /// <summary>
        ///     Start main game logic for each element in game.
        ///     Move it, if it is alive or do actions.
        /// </summary>
        private void StartLogic()
        {
            foreach (var gameObject in Map.GameObjects)
            {
                if (gameObject.IsAlive)
                {
                    MoveObjects(gameObject);

                    var gameO = gameObject as Employee;

                    if (gameO != null)
                    {
                        AliveObjectActions(gameO);
                    }
                }
            }
            CollectionClear();
        }

        /// <summary>
        ///     Actions for alive object in game. 
        ///     Greet with other employees or do work.
        /// </summary>
        /// <param name="employee">Employee instance</param>
        private void AliveObjectActions(Employee employee)
        {
            foreach (var gameObject in Map.GameObjects)
            {
                if (employee != gameObject
                    && employee.Position == gameObject.Position)
                {
                    var empl = gameObject as Employee;

                    if (empl != null)
                    {
                        Console.Clear();
                        Greet(employee, empl);
                    }
                    else
                    {
                        var worker = employee as Worker;
                        var work = gameObject as Work;
                        if (worker != null && work != null)
                        {
                            CollectWork(worker, work);
                        }
                    }
                }
            }
        }

        #region MovementLogic
        /// <summary>
        /// If object's IsAlive is True, change object position.
        /// </summary>
        private void MoveObjects(GameObject gameObject)
        {
            dice.ChangeObjectPosition(gameObject);
        }

        #endregion

        #region GreetingLogic
        /// <summary>
        ///     If two alive employees have same position, call method 
        /// </summary>        
        private void Greet(Employee firstAliveObject, Employee secondAliveObject)
        {
            GreetLogic(firstAliveObject, secondAliveObject);
            GreetLogic(secondAliveObject, firstAliveObject);
        }

        /// <summary>
        ///     Greet main logic
        /// </summary>
        /// <param name="firstAliveObject">Employee instance</param>
        /// <param name="secondAliveObject">Employee instance</param>
        private void GreetLogic(Employee firstAliveObject, Employee secondAliveObject)
        {
            if (firstAliveObject is Worker)
            {
                (firstAliveObject as Worker).Talk((secondAliveObject));
            }
            else if (firstAliveObject is BigBoss)
            {
                (firstAliveObject as BigBoss).Talk((secondAliveObject));
            }
            else if (firstAliveObject is Boss)
            {
                (firstAliveObject as Boss).Talk((secondAliveObject));
            }
            Thread.Sleep(delayTime);
        }
        #endregion

        #region WorkingLogic
        /// <summary>
        ///     If Worker position equals work object position, collect work.
        /// </summary>
        /// <param name="worker">Worker class instance</param>
        private void CollectWork(Worker worker, Work work)
        {
            worker.DoWork(work);
        }

        /// <summary>
        ///     Remove collected work instances
        /// </summary>
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
        #endregion
    }
}
