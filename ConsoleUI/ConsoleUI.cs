using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Interfaces.UI;
using System;

namespace ConsoleUI
{
    class ConsoleUI : IUI
    {       
        public ConsoleUI()
        {
        }

        /// <summary>
        ///     Shows current map
        /// </summary>
        /// <param name="map">Map instance</param>
        public void ShowMap(IMap map)
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
        }

        /// <summary>
        ///    Initial initialization. Creates empty field.
        /// </summary>
        /// <param name="map">Map instance</param>
        public void ShowHourCounter(IMap map, int hourCounter)
        {
            Console.SetCursorPosition(map.Width + 10, 0);
            Console.WriteLine(string.Format("Hour Counter:  {0}",
                hourCounter));
        }
    }
}
