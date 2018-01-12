using System.Collections.Generic;

namespace InterfaceLibrary.Interfaces.Infrastructure
{
    public interface IGameObjectList<T> : IList<T> where T : IGameObject
    {
        
    }
}
