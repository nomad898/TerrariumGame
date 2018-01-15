using InterfaceLibrary.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Models;
using System.Collections;
using InterfaceLibrary.Interfaces;

namespace TerrariumGame.Infrastructure
{
    public class GameObjectList : IGameObjectList
    {
        class Node
        {
            Node 
        }

        public IGameObject this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(IGameObject item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IGameObject item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IGameObject[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IGameObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(IGameObject item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IGameObject item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IGameObject item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
