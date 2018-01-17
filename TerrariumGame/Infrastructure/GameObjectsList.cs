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

            public Node() { }

            public Node(IGameObject item)
            {
                Data = item;
            }
        }

        /// <summary>
        ///     The first element in the list
        /// </summary>
        private Node head = null;
        
        /// <summary>
        ///     Returns the first item.
        /// </summary>
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

        /// <summary>
        ///     Returns the last item.
        /// </summary>
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
                            return;
                        }
                        current = current.Next;
                    }
                }
                throw new ArgumentOutOfRangeException(
                   string.Format("Element with index {0} does not exist", index));
            }
        }

        private int count = 0;

        /// <summary>
        ///     Returns the number of items.
        /// </summary>
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

        /// <summary>
        ///     Add a new item to the list.
        /// </summary>
        /// <param name="item">Game object</param>
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

        /// <summary>
        ///     Add a new item to the end of the list.
        /// </summary>
        /// <param name="item">Game object</param>
        private void AddToEnd(IGameObject item)
        {
            Node last = Last;
            Node newNode = new Node(item);
            last.Next = newNode;
            newNode.Index = indexCounter;
            indexCounter++;
        }

        /// <summary>
        ///     Delete all items.
        /// </summary>
        public void Clear()
        {
            foreach (var el in this)
            {
                this.Remove(el);
            }
            count = 0;
        }

        /// <summary>
        ///     Shows if the item is in the list.
        /// </summary>
        /// <param name="item">Game object</param>
        /// <returns>Is contains</returns>
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

        //TODO
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

        /// <summary>
        ///     Returns the index of the item if it is in the list.
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>item's index</returns>
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

        //TODO
        public void Insert(int index, IGameObject item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Delete the item in the list.
        /// </summary>
        /// <param name="item">Game object</param>
        /// <returns>Is deleted</returns>
        public bool Remove(IGameObject item)
        {
            if (this.Contains(item))
            {
                Node current = null;
                if (First.Data == item)
                {
                    DeleteFirstItem(ref current, item);
                }
                else
                {
                    DeleteNoFirstItem(ref current, item);
                }
                IndexDecrement(current);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Delete the first item.
        /// </summary>
        /// <param name="current">Current node</param>
        /// <param name="item">item to remove</param>
        private void DeleteFirstItem(ref Node current, IGameObject item)
        {
            First = First.Next;
            current = First;
        }
        /// <summary>
        ///     Delete not the first item.
        /// </summary>
        /// <param name="current">Current node</param>
        /// <param name="item">item to remove</param>
        private void DeleteNoFirstItem(ref Node current, IGameObject item)
        {
            current = First;
            Node prev = null;
            if (current != null)
            {
                while (current.Data != item)
                {
                    prev = current;
                    current = current.Next;
                }
            }
            if (current != null)
                prev.Next = current.Next;
            current = current.Next;
        }

        /// <summary>
        ///     Change the values of the indices.
        /// </summary>
        /// <param name="current">Current node</param>
        private void IndexDecrement(Node current)
        {
            while (current != null)
            {
                --current.Index;
                current = current.Next;
            }
            --indexCounter;
            --count;
        }

        //TODO
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