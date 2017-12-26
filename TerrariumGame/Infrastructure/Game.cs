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
                for (int minute = 0; minute < minutesInHour; minute++)
                {
                    Play(Map);
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

        private void Play(Map map)
        {           
            MoveObjects();
            GreetAlivePeople();
            GoWork();
        }

        //#region InGameObjects
        ///// <summary>
        ///// Contains objects that have IsAlive - True
        ///// </summary>
        //ICollection<GameObject> aliveObjects = new List<GameObject>();

        ///// <summary>
        ///// Contains objects that have IsAlive - False
        ///// </summary>
        //ICollection<GameObject> notAliveObjects = new List<GameObject>();        
        //#endregion 

        #region MovementLogic
        /// <summary>
        /// If object's IsAlive is True, change object position
        /// and add it to aliveObjects list.
        /// Or IsAlive is False, add it to notAliveObjects list.
        /// </summary>
        private void MoveObjects()
        {
            foreach (var obj in Map.GameObjects)
            {
                if (obj.IsAlive)
                {
                    dice.ChangeObjectPosition(obj);
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
            foreach (var worker in Map.GameObjects)
            {
                if (worker.IsAlive && worker is Worker)
                {
                    CollectWork(worker as Worker);
                }
            }
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

                    break;
                }
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
            foreach (var aliveObject in Map.GameObjects)
            {
                foreach (var aliveO in Map.GameObjects)
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
