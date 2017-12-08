using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame.Infrastructure
{
    class MapManipulator
    {
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

        public void FillMap(Map map)
        {
            MapInit(map);
            foreach (var obj in map.GameObjects)
            {
                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                map[obj.Position.X, obj.Position.Y] = obj.Icon;
            }
        }
    }
}
