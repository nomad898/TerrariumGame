using InterfaceLibrary.Interfaces;
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
        public IMap Map
        {
            get
            {
                return map;
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
        private const int minutesInHour = 30;
        private const int timeDelay = 1000;
        private Random random;

        private readonly IMap map;
        private readonly IMapManipulator mapManipulator;
        private readonly IDice dice;
        private readonly IMessageWriter msgWriter;
        #endregion
        #endregion
        #region Ctor
        public Game(IMap map,
            IMapManipulator mapManipulator,
            IDice dice,
            IMessageWriter msgWriter)
        {            
            if (map == null)
            {
                throw new ArgumentNullException("Map is null");
            }
            if (mapManipulator == null)
            {
                throw new ArgumentNullException("MapManipulator is null");
            }
            if (dice == null)
            {
                throw new ArgumentNullException("Dice is null");
            }
            if (msgWriter == null)
            {
                throw new ArgumentNullException("MessageWriter is null");
            }
            random = new Random();
            this.map = map;
            this.mapManipulator = mapManipulator;
            this.dice = dice;
            this.msgWriter = msgWriter;
        }
        #endregion
        /// <summary>
        /// Start game
        /// </summary>
        public void Start()
        {
            mapManipulator.ShowMap();
            while (gameIsRunning)
            {
                for (int minute = 0; minute < minutesInHour; minute++)
                {                  
                    StartLogic();
                    mapManipulator.SetObjects();
                    mapManipulator.ShowMap();
                    Thread.Sleep(timeDelay);
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
            foreach (var gameObject in Map.GameObjects)
            {
                if (employee != gameObject
                    && employee.Position == gameObject.Position)
                {
                    var empl = gameObject as IEmployee;

                    if (empl != null)
                    {
                        Greet(employee, empl);
                    }
                    else
                    {
                        var worker = employee as IWorker;
                        var work = gameObject as IWork;
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
        private void MoveObjects(IGameObject gameObject)
        {
            dice.ChangeObjectPosition(gameObject);
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
            msgWriter.PrintMessage(talkResult, MessageType.ConversationMsg);
            //Console.WriteLine(talkResult);
            //Thread.Sleep(timeDelay + 1000);
            //Console.SetCursorPosition(Map.Width + 10, 2);
            //Console.WriteLine(new string(' ', 100));
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

        /// <summary>
        ///     Remove collected work instances
        /// </summary>
        private void CollectionClear()
        {
            (Map.GameObjects as List<IGameObject>)
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
                if (Map.GameObjects[obj] is ICustomer)
                {
                    var newWork = (Map.GameObjects[obj] as ICustomer)
                        .CreateWork();
                    Map.GameObjects.Add(newWork);
                }
            }
        }
        #endregion
        #endregion
    }
}
