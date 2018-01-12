using InterfaceLibrary.UtilityModels;

namespace InterfaceLibrary.Interfaces
{
    public interface IMovable
    {
        char Icon { get; }
        Point Position { get; set; }
        void Move(Point p);
    }
}
