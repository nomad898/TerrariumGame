using InterfaceLibrary.Interfaces.UI;
using InterfaceLibrary.Interfaces.Writer;

namespace InterfaceLibrary.Interfaces
{
    public interface IMapManipulator
    {
        IGameObjectFactory GameObjectFactory { get; }
        
        void SetObjects(IMap map);
        void Init(IMap map); 
    }
}
