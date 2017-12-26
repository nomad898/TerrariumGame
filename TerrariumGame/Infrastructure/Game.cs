﻿using System;
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
        private const int delayTime = 1000;

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

        private void StartLogic()
        {
            foreach(var gameObject in Map.GameObjects)
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

        private void AliveObjectActions(Employee employee)
        {
            foreach (var gameObject in Map.GameObjects)
            {
                var empl = gameObject as Employee;

                if (empl != null
                    && employee.Position == empl.Position
                    && employee != empl)
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

        #region GreetingLogic
        /// <summary>
        ///     If two alive employees have same position, call methods 
        /// </summary>        
        private void Greet(Employee firstAliveObject, Employee secondAliveObject)
        {
            GreetLogic(firstAliveObject, secondAliveObject);
            GreetLogic(secondAliveObject, firstAliveObject);
        }

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
        ///     If Worker position equals work object, collect work.
        /// </summary>
        /// <param name="worker">Worker class instance</param>
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
    }
}
