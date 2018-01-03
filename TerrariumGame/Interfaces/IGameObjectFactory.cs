using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IGameObjectFactory : IFactory<IGameObject>
    {
        int IdBegin { get; }
        int IdEnd { get; }
        
        IGameObject Create(int id, int x, int y);
        IGameObject Create(int id, string name, int x, int y);
    }
}
