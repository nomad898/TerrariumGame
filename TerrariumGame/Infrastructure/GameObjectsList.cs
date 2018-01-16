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
    public class GameObjectsList : IGameObjectsList
    {
        public class Node
        {
            private Node next = null;
            private IGameObject data;
            private int index;

            public Node Next
            {
                get
                {
                    return next;
                }
                set
                {
                    next = value;
                }
            }
            public IGameObject Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
            public int Index
            {
                get
                {
                    return index;
                }
                set
                {
                    index = value;
                }
            }
        }

        public GameObjectsList()
        {
            gameObjects = new Node[capacity];
        }

        private Node[] gameObjects;

        private const int SIZE_INDEX = 2;

        private int capacity = 10;
        private int indexCounter = 0;

        private void EnsureCapacity()
        {
            capacity = capacity * 2;
        }

        private Node head = null;

        public Node First
        {
            get
            {
                return head;
            }
        }

        public Node Last
        {
            get
            {
                Node current = First;
                if (current == null)
                {
                    return null;
                }
                while (current.Next != null)
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public IGameObject this[int index]
        {
            get
            {
                try
                {
                    return gameObjects[index].Data;
                }
                catch (NullReferenceException ex)
                {
                    throw new ArgumentOutOfRangeException
                        (string.Format("Element with index {0} doesn't exist", index));
                }
            }

            set
            {
                gameObjects[index].Data = value;
            }
        }

        public int Count
        {
            get
            {
                if (Last != null)
                {
                    return Last.Index + 1;
                }
                return 0;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return gameObjects.IsReadOnly;
            }
        }

        public void Add(IGameObject item)
        {
            if (Count == capacity)
            {
                EnsureCapacity();
            }

            Node node = new Node
            {
                Data = item,
                Index = this.indexCounter
            };

            this.indexCounter++;

            if (head == null)
            {
                head = node;
            }
            else
            {
                Last.Next = node;
            }
            if (Last.Index == 0)
            {
                gameObjects[Last.Index] = node;
            }
            else
            {
                gameObjects[Last.Index + 1] = node;
            }
        }

        public void Clear()
        {
            gameObjects = new Node[capacity];
        }

        public bool Contains(IGameObject item)
        {
            foreach (var go in gameObjects)
            {
                if (go.Data == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(IGameObject[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IGameObject> GetEnumerator()
        {
            foreach (var go in gameObjects)
            {
                if (go == null)
                {
                    break;
                }
                yield return go.Data;
            }
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
            return this.GetEnumerator();
        }
    }
}
