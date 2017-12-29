using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;

namespace TerrariumGame.Interfaces
{
    interface IMap
    {
        int Height { get; set; }
        int Width { get; set; }
        char[,] Matrix { get; set; }
        IList<GameObject> GameObjects { get; set; }
        char this[int x, int y] { get; set; }
    }
}
