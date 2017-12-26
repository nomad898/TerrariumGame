using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure.Factory;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class MapManipulator
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
        #endregion
        #region Private
        private int minObjectAmount = 4;
        private int maxObjectAmount = 12;
        private const int maxHour = 8;
        private int hourCounter = 0;
        Random random = new Random();
        #endregion
        #endregion

        /// <summary>
        ///     Shows current map
        /// </summary>
        /// <param name="map">Map instance</param>
        public void ShowMap(Map map)
        {
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(map.Width + 10, 0);
            Console.WriteLine(string.Format("Hour Counter:  {0}",
                this.HourCounter));
        }

        /// <summary>
        ///     Place the objects on the map
        /// </summary>
        /// <param name="map">Map instance</param>
        public void SetObjects(Map map)
        {
            MapInit(map);
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
        public void Init(Map map)
        {
            MapInit(map);
            ObjectsInit(map);
        }
        
        /// <summary>
        ///    Initial initialization. Creates empty field.
        /// </summary>
        /// <param name="map">Map instance</param>
        private void MapInit(Map map)
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
        
        /// <summary>
        ///     Creates new objects.
        /// </summary>
        /// <param name="map">Map instance</param>
        private void ObjectsInit(Map map)
        {
            int counterValue = random.Next(minObjectAmount, maxObjectAmount);
            for (int i = 0; i < counterValue; i++)
            {
                map.GameObjects.Add(GameObjectFactory.Create(random.Next(1, 6),
                    objectId.ToString(),
                    random.Next(0, map.Height),
                    random.Next(0, map.Width)));
                objectId++;
            }
        }
    }
}
