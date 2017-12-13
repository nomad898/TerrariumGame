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
        private int minObjectAmount = 4;
        private int maxObjectAmount = 12;
        Random random = new Random();

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
        }

        public void SetObjects(Map map)
        {
            MapInit(map);
            foreach (var obj in map.GameObjects)
            {
                if (obj.Position.X >= 0
                    && obj.Position.Y >= 0)
                {
                    Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                    map[obj.Position.X, obj.Position.Y] = obj.Icon;
                }
            }
        }

        public void Init(Map map)
        {
            MapInit(map);
            ObjectsInit(map);
        }

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
