using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IMap
    {
        int Height { get; set; }
        int Width { get; set; }
        char[,] Matrix { get; set; }
        IList<IGameObject> GameObjects { get; }
        char this[int x, int y] { get; set; }
    }
}
