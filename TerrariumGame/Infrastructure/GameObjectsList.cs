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

            public Node() { }

            public Node(IGameObject item)
            {
                Data = item;
            }
        }

        private Node head = null;

        public Node First
        {
            get
            {
                return head;
            }
            private set
            {
                head = value;
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
                if (Count > index)
                {
                    Node current = First;
                    while (current != null)
                    {
                        if (current.Index == index)
                        {
                            return current.Data;
                        }
                        current = current.Next;
                    }
                }
                throw new ArgumentOutOfRangeException(
                    string.Format("Element with index {0} does not exist", index));
            }
            set
            {
                if (Count > index)
                {
                    Node current = First;
                    while (current != null)
                    {
                        if (current.Index == index)
                        {
                            current.Data = value;
                        }
                        current = current.Next;
                    }
                }
                throw new ArgumentOutOfRangeException(
                   string.Format("Element with index {0} does not exist", index));
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
                head.Index = 0;
            }
            else
            {
                AddToEnd(item);
            }
            count++;
        }

        private int indexCounter = 1;

        private void AddToEnd(IGameObject item)
        {
            Node last = Last;
            Node newNode = new Node(item);
            last.Next = newNode;
            newNode.Index = indexCounter;
            indexCounter++;
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
            Node current = First;
            while (current != null)
            {
                if (current.Data == item)
                {
                    return current.Index;
                }
                current = current.Next;
            }
            return -1;
        }

        public void Insert(int index, IGameObject item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IGameObject item)
        {
            if (this.Contains(item))
            {
                Node current, temp;
                if (First.Data == item)
                {
                    First = First.Next;
                    current = First;
                    temp = current;
                }               
                else 
                {
                    current = First;
                    Node prev = current;
                    if (current != null)
                    {
                        while (current.Data != item)
                        {
                            prev = current;
                            current = current.Next;
                        }
                    }
                    if (current != null && prev != null)
                        prev.Next = current.Next;
                    temp = current.Next;
                }              
                while (temp != null)
                {
                    --temp.Index;
                    temp = temp.Next;
                }
                current = null;
                --indexCounter;
                --count;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (Count > index)
            {
                Node current = First;
                Node prev = null;
                while (current.Index != index)
                {
                    prev = current;
                    current = current.Next;
                }
                if (current != null && prev != null)
                    prev.Next = current.Next;
                current = null;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}