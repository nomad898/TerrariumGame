using BusinessLibrary.Clients;
using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.UI;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Models;
using TerrariumGame.Models.Alive;
using TerrariumGame.Models.NotAlive;

namespace TerrariumGame.Infrastructure
{
    public class Game : IGame
    {
        #region Fields
        #region Public
        public bool GameIsRunning
        {
            get
            {
                return gameIsRunning;
            }
            set
            {
                gameIsRunning = value;
            }
        }
        public int HourCounter
        {
            get
            {
                return hourCounter;
            }
        }
        public int MaxHour
        {
            get
            {
                return MAX_HOUR;
            }
        }
        public IMapManipulator MapManipulator
        {
            get
            {
                return mapManipulator;
            }
        }
        public IDice Dice
        {
            get
            {
                return dice;
            }
        }
        public IUI UI { get { return ui; } }
        public IMessageWriter MessageWriter
        {
            get
            {
                return msgWriter;
            }
        }
        #endregion
        #region Private
        private bool gameIsRunning = true;

        /// <summary>
        ///     Hour duration
        /// </summary>
        private int hourCounter = 0;
        private const int MAX_HOUR = 8;
        private const int MINUTES_IN_HOUR = 30;
        private const int TIME_DELAY = 300;
        private Random random;

        private readonly IMapManipulator mapManipulator;
        private readonly IMap map;
        private readonly IDice dice;
        private readonly IUI ui;
        private readonly IMessageWriter msgWriter;
        #endregion
        #endregion
        #region Ctor
        public Game(IMapManipulator mapManipulator,
            IMap map,
            IDice dice,
            IUI ui,
            IMessageWriter msgWriter)
        {
            if (mapManipulator == null)
            {
                throw new ArgumentNullException("MapManipulator is null");
            }
            if (map == null)
            {
                throw new ArgumentNullException("Map is null");
            }
            if (dice == null)
            {
                throw new ArgumentNullException("Dice is null");
            }
            if (ui == null)
            {
                throw new ArgumentNullException("UI is null");
            }
            if (msgWriter == null)
            {
                throw new ArgumentNullException("MessageWriter is null");
            }
            random = new Random();
            this.mapManipulator = mapManipulator;
            this.map = map;
            this.dice = dice;
            this.ui = ui;
            this.msgWriter = msgWriter;
        }
        #endregion
        /// <summary>
        /// Start game
        /// </summary>
        public void Start(bool withDelay)
        {
            mapManipulator.Init(map);
            UI.ShowMap(map);
            while (gameIsRunning)
            {
                for (int minute = 0; minute < MINUTES_IN_HOUR; minute++)
                {
                    StartLogic();
                    mapManipulator.SetObjects(map);
                    UI.ShowMap(map);
                    UI.ShowHourCounter(map, this.HourCounter);
                    if (withDelay)
                        Thread.Sleep(TIME_DELAY);
                }
                this.hourCounter++;

                if (this.HourCounter == this.MaxHour)
                {
                    gameIsRunning = false;
                }

                CreateNewItems();
            }
        }

        #region GameLogic
        /// <summary>
        ///     Start main game logic for each element in game.
        ///     Move it, if it is alive or do actions.
        /// </summary>
        private void StartLogic()
        {
            foreach (var gameObject in map.GameObjects)
            {
                if (gameObject.IsAlive)
                {
                    MoveObjects(gameObject);

                    var gameO = gameObject as IEmployee;

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
        private void AliveObjectActions(IEmployee employee)
        {
            foreach (var gameObject in map.GameObjects)
            {
                if (employee != gameObject
                    && employee.Position == gameObject.Position)
                {
                    if (gameObject is IEmployee)
                    {
                        var empl = gameObject as IEmployee;

                        if (empl != null)
                        {
                            Greet(employee, empl);
                        }
                    }
                    else if (gameObject is IWork)
                    {
                        var worker = employee as IWorker;
                        var work = gameObject as IWork;
                        if (worker != null && work != null)
                        {
                            CollectWork(worker, work);
                        }
                    }
                    else if (gameObject is ISalaryAddition)
                    {
                        var mngbl = employee as IManagable;
                        var salary = gameObject as ISalaryAddition;
                        if (mngbl != null && salary != null)
                        {
                            CollectSalaryAddition(mngbl, salary);
                        }
                    }
                }
            }
        }

        #region MovementLogic
        /// <summary>
        /// If object's IsAlive is True, change object position.
        /// </summary>
        private void MoveObjects(IGameObject gameObject)
        {
            dice.ChangeObjectPosition(gameObject, map);
        }
        #endregion

        #region GreetingLogic
        /// <summary>
        ///     If two alive employees have same position, call method 
        /// </summary>        
        private void Greet(IEmployee firstAliveObject, IEmployee secondAliveObject)
        {
            GreetLogic(firstAliveObject, secondAliveObject);
            GreetLogic(secondAliveObject, firstAliveObject);
        }

        /// <summary>
        ///     Greet main logic
        /// </summary>
        /// <param name="firstAliveObject">Employee instance</param>
        /// <param name="secondAliveObject">Employee instance</param>
        private void GreetLogic(IEmployee firstAliveObject, IEmployee secondAliveObject)
        {
            string talkResult = string.Empty;
            if (firstAliveObject is IWorker)
            {
                talkResult = (firstAliveObject as IWorker).Talk((secondAliveObject));
            }
            else if (firstAliveObject is IBigBoss)
            {
                talkResult = (firstAliveObject as IBigBoss).Talk((secondAliveObject));
            }
            else if (firstAliveObject is IBoss)
            {
                talkResult = (firstAliveObject as IBoss).Talk((secondAliveObject));
            }

            if (msgWriter != null)
            {
                msgWriter.PrintMessage(talkResult);
            }
        }
        #endregion

        #region WorkingLogic
        /// <summary>
        ///     If Worker position equals work object position, collect work.
        /// </summary>
        /// <param name="worker">Worker class instance</param>
        private void CollectWork(IWorker worker, IWork work)
        {
            worker.DoWork(work);
        }

        private void CollectSalaryAddition(IManagable mngbl, ISalaryAddition salary)
        {
            mngbl.TakeSalaryAddition(salary);
        }

        /// <summary>
        ///     Remove collected work instances
        /// </summary>
        private void CollectionClear()
        {
            for (int i = 0; i < map.GameObjects.Count; i++)
            {
                if (map.GameObjects[i].State
                    == State.Deleted)
                {
                    map.GameObjects.Remove(
                        map.GameObjects[i]);
                }
            }
        }

        /// <summary>
        /// Customers create new Work object to the Map
        /// </summary>
        private void CreateNewItems()
        {
            foreach (var el in map.GameObjects)
            {
                CreateNewWork(el);
                CreateNewSalaryAddition(el);
            }
        }

        private void CreateNewWork(IGameObject gameObject)
        {
            var customer = gameObject as ICustomer;
            if (customer != null)
            {
                var newWork = customer.CreateWork();
                map.GameObjects.Add(newWork);
            }
        }

        private void CreateNewSalaryAddition(IGameObject gameObject)
        {
            var bigBoss = gameObject as IBigBoss;
            if (bigBoss != null)
            {
                var salaryAddition = bigBoss.CreateSalaryAddition();
                map.GameObjects.Add(salaryAddition);
            }
        }
        #endregion
        #endregion
    }
}
