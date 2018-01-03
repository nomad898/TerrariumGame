using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Interfaces;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class MapManipulator : IMapManipulator
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

        public IFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        #endregion
        #region Private
        private int minObjectAmount = 4;
        private int maxObjectAmount = 12;
        private const int maxHour = 8;
        private int hourCounter = 0;
        private Random random;
        private IMap map;
        private IFactory factory;
        #endregion
        #endregion

        public MapManipulator(IMap map, IFactory factory)
        {
            random = new Random();
            this.map = map;
            this.factory = factory;
            Init();
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

        private static int objectId = 1;
        private int createIdFirst = 1;
        private int createIdSecond = 6;

        /// <summary>
        ///     Creates new objects.
        /// </summary>
        /// <param name="map">Map instance</param>
        private void ObjectsInit()
        {
            int counterValue = random.Next(minObjectAmount, maxObjectAmount);
            for (int i = 0; i < counterValue; i++)
            {
                map.GameObjects.Add(factory.Create(random.Next(
                    createIdFirst,
                    createIdSecond),
                    objectId.ToString(),
                    random.Next(0, map.Height),
                    random.Next(0, map.Width)));
                objectId++;
            }
        }
    }
}
