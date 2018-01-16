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
        public GameObjectsList()
        {

        }

        public class Node
        {
            private Node next = null;
            private IGameObject data;

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

            public Node() { }

            public Node(IGameObject item)
            {
                Data = item;
            }

            public void AddToEnd(IGameObject item)
            {
                if (next == null)
                {
                    next = new Node(item);
                }
                else
                {
                    next.AddToEnd(item);
                }
            }
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
            private set
            {
                Last = value;
            }
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

        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(IGameObject item)
        {
            if (head == null)
            {
                head = new Node(item);
            }
            else
            {
                head.AddToEnd(item);
            }
            count++;
        }

        public void Clear()
        {
            while (Last != null)
            {
                Last = null;
            }
            count = 0;
        }

        public bool Contains(IGameObject item)
        {
            if (item != null)
            {
                Node current = First;
                while (current != null)
                {
                    if (current.Data == item)
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void CopyTo(IGameObject[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IGameObject> GetEnumerator()
        {
            Node current = First;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
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
            if (this.Contains(item))
            {
                Node current = First;
                Node prev = null;
                while (current.Data != item)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = current.Next;
                current = null;
                count -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}