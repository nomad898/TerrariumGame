using InterfaceLibrary.Interfaces.Infrastructure;

namespace InterfaceLibrary.Interfaces
{
    public interface IMap
    {
        int Height { get; set; }
        int Width { get; set; }
        char[,] Matrix { get; set; }
        IGameObjectsList GameObjects { get; }
        char this[int x, int y] { get; set; }
    }
}
