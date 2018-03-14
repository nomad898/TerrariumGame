using InterfaceLibrary.Interfaces.UI;
using InterfaceLibrary.Interfaces.Writer;

namespace InterfaceLibrary.Interfaces
{
    public interface IGame
    {
        bool GameIsRunning { get; set; }
        int HourCounter
        {
            get;
        }
        int MaxHour
        {
            get;
        }

        IUI UI { get; }
        IMapManipulator MapManipulator { get; }
        IDice Dice { get; } 
        IMessageWriter MessageWriter { get; }      

        void Start(bool withDelay);
    }
}
