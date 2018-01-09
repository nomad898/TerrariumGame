using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IGameObjectFactory : IFactory<IGameObject>
    {
        IGameObject Create(int id, int x, int y);
        IGameObject Create(int id, string name, int x, int y);
    }
}
