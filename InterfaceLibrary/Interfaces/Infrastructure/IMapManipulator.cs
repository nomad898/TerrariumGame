using InterfaceLibrary.Interfaces.Writer;

namespace InterfaceLibrary.Interfaces
{
    public interface IMapManipulator
    {
        int HourCounter
        {
            get; set;
        }

        int MaxHour { get; }

        IMap Map { get; set; }

        IGameObjectFactory GameObjectFactory { get; set; }

        IMessageWriter MessageWriter { get; }

        void ShowMap();

        void SetObjects();        
    }
}
