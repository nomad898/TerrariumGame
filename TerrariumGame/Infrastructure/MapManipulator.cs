using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.UI;
using InterfaceLibrary.Interfaces.Writer;
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
        public IMap Map
        {
            get
            {
                return map;
            }
        }

        public IGameObjectFactory GameObjectFactory
        {
            get
            {
                return gOFactory;
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
        
        private Random random;
        private readonly IMap map;
        private readonly IGameObjectFactory gOFactory;
        private readonly IMessageWriter msgWriter;
        #endregion
        #endregion
        public MapManipulator(IMap map,
            IGameObjectFactory factory,          
            IMessageWriter msgWriter)
        {
            if (map == null)
            {
                throw new ArgumentNullException("Map is null");
            }
            if (factory == null)
            {
                throw new ArgumentNullException("Game factory is null");
            }
            if (msgWriter == null)
            {
                throw new ArgumentNullException("MessageWriter is null");
            }
            random = new Random();
            this.map = map;
            this.gOFactory = factory;
            this.msgWriter = msgWriter;
            minObjectAmount = Config.MIN_OBJECT_AMOUNT;
            maxObjectAmount = Config.MAX_OBJECT_AMOUNT;
            idBegin = Config.BEGIN_OBJECT_ID;
            idEnd = Config.END_OBJECT_ID;

            Init();
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


        private void MapInit()
        {
            for (int x = 0; x < map.Height; x++)
            {
                for (int y = 0; y < map.Width; y++)
                {
                    map[x, y] = '.';
                }
            }
        }

        #region Create GameObjects Logic
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
                map.GameObjects.Add(gOFactory.Create(
                    random.Next(idBegin, idEnd),
                    objectId.ToString(),
                    random.Next(salaryMinValue, salaryMaxValue),
                    random.Next(0, map.Height),
                    random.Next(0, map.Width)));
                objectId++;
            }
        }
        #endregion
    }
}
