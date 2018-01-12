using InterfaceLibrary.Interfaces.Writer;

namespace InterfaceLibrary.Interfaces
{
    public interface IGame
    {
        bool GameIsRunning { get; set; }

        // IMap Map { get; }
        IMapManipulator MapManipulator { get; }
        IDice Dice { get; } 
        IMessageWriter MessageWriter { get; }      

        void Start();
    }
}
