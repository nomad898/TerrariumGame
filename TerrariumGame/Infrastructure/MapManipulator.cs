using InterfaceLibrary.Interfaces;
using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    public class MapManipulator : IMapManipulator
    {
        #region Fields
        #region Public
        public int HourCounter
        {
            get
            {
                return hourCounter;
            }
            set
            {
                hourCounter = value;
            }
        }

        public int MaxHour { get { return maxHour; } }

        public IMap Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

        public IGameObjectFactory GameObjectFactory
        {
            get
            {
                return gOFactory;
            }
            set
            {
                gOFactory = value;
            }
        }

        #endregion
        #region Private
        private const int maxHour = 8;
        private int hourCounter = 0;
        private Random random;
        private IMap map;
        private IGameObjectFactory gOFactory;
        #endregion
        #endregion
        public MapManipulator(IMap map,
            IGameObjectFactory factory)
        {
            if (map == null)
            {
                throw new ArgumentNullException("Map is null");
            }
            if (factory == null)
            {
                throw new ArgumentNullException("Game factory is null");
            }
            random = new Random();
            this.map = map;
            this.gOFactory = factory;
            minObjectAmount = Config.MIN_OBJECT_AMOUNT;
            maxObjectAmount = Config.MAX_OBJECT_AMOUNT;
            idBegin = Config.BEGIN_OBJECT_ID;
            idEnd = Config.END_OBJECT_ID;

            Init();
        }

        public MapManipulator(IMap map, 
            IGameObjectFactory factory, 
            int minObjectAmount, 
            int maxObjectAmount, 
            int begin, 
            int end)
        {
            if (map == null)
            {
                throw new ArgumentNullException("Map is null");
            }
            if (factory == null)
            {
                throw new ArgumentNullException("Game factory is null");
            }
            random = new Random();
            this.map = map;
            this.gOFactory = factory;

            if (minObjectAmount < maxObjectAmount)
            {
                ExchangeValues(ref minObjectAmount, ref maxObjectAmount);
            }

            this.minObjectAmount = minObjectAmount;
            this.maxObjectAmount = maxObjectAmount;

            if (begin > end)
            {
                ExchangeValues(ref begin, ref end);
            }

            idBegin = begin;
            idEnd = end;
            Init();
        }

        // temporarily
        private void ExchangeValues(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = x;
        }

        /// <summary>
        ///     Shows current map
        /// </summary>
        /// <param name="map">Map instance</param>
        public void ShowMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }

            ShowHourCounter();
        }

        /// <summary>
        ///     Place the objects on the map
        /// </summary>
        /// <param name="map">Map instance</param>
        public void SetObjects()
        {
            MapInit();
            foreach (var obj in map.GameObjects)
            {
                if (obj.Position.X >= 0
                    && obj.Position.Y >= 0
                    && obj.State == State.InGame)
                {
                    Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                    map[obj.Position.X, obj.Position.Y] = obj.Icon;
                }
            }
        }

        /// <summary>
        ///     Map initialization
        /// </summary>
        /// <param name="map">Map instance</param>
        private void Init()
        {
            MapInit();
            ObjectsInit();
        }

        private void ShowHourCounter()
        {
            Console.SetCursorPosition(map.Width + 10, 0);
            Console.WriteLine(string.Format("Hour Counter:  {0}",
                this.HourCounter));
        }

        /// <summary>
        ///    Initial initialization. Creates empty field.
        /// </summary>
        /// <param name="map">Map instance</param>
        private void MapInit()
        {
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    map[x, y] = '.';
                }
                Console.WriteLine();
            }
        }

        #region Create GameObject Logic
        private static int objectId = 1;
        private readonly int idBegin;
        private readonly int idEnd;
        private readonly int minObjectAmount;
        private readonly int maxObjectAmount;
        private const int salaryMinValue = 10000;
        private const int salaryMaxValue = 20000;

        /// <summary>
        ///     Creates new objects.
        /// </summary>
        /// <param name="map">Map instance</param>
        private void ObjectsInit()
        {
            int counterValue = random.Next(minObjectAmount, maxObjectAmount);
            for (int i = 0; i < counterValue; i++)
            {
                map.GameObjects.Add(gOFactory.Create(random.Next(
                    idBegin,
                    idEnd),
                    objectId.ToString(),
                    random.Next(
                        salaryMinValue,
                        salaryMaxValue),
                    random.Next(0, map.Height),
                    random.Next(0, map.Width)));
                objectId++;
            }
        }
        #endregion
    }
}
