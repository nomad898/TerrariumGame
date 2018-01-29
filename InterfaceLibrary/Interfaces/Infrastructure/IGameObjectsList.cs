using System.Collections.Generic;

namespace InterfaceLibrary.Interfaces.Infrastructure
{
    public interface IGameObjectsList : IList<IGameObject>
    {
        IGameObject First { get; }
        IGameObject Last { get; }
        List<IGameObject> ToList();
        void CopyTo(IGameObject[] array);
        void CopyTo(int index, IGameObject[] array,
            int arrayIndex, int count);
    }
}
