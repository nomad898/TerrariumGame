﻿using InterfaceLibrary.Interfaces.Infrastructure;
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
                if (Count > index && index >= 0)
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
                if (Count > index && index >= 0)
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
                for (Node current = First; current != null;
                    current = current.Next)
                {
                    if (current.Data == item)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void CopyTo(IGameObject[] array)
        {
            if (array.Length >= Count)
            {
                Node current = First;
                for (int arrayIndex = 0; arrayIndex <= array.Length;
                    current = current.Next, arrayIndex++)
                {
                    if (current == null)
                    {
                        break;
                    }
                    array[arrayIndex] = current.Data;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void CopyTo(IGameObject[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex >= Count)
            {
                for (Node current = First; current != null;
                    current = current.Next, arrayIndex++)
                {
                    array[arrayIndex] = current.Data;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void CopyTo(int index, IGameObject[] array,
            int arrayIndex, int count)
        {
            for (Node current = First; current != null;
                current = current.Next, arrayIndex++, index++, count--)
            {
                if (count == 0)
                {
                    break;
                }
                array[arrayIndex] = this[index];
            }
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

        public void Insert(int index, IGameObject item)
        {
            if (Count > index && index >= 0)
            {
                var current = First;
                while (current.Index != index)
                {
                    current = current.Next;
                }
                var oldCurrentData = current.Data;
                current.Data = item;
                current = current.Next;
                while (current != null)
                {
                    var temp = current.Data;
                    current.Data = oldCurrentData;
                    current = current.Next;
                    oldCurrentData = temp;
                }
                this.AddToEnd(oldCurrentData);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
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
            for (; current != null; current = current.Next)
            {
                --current.Index;
            }
            --indexCounter;
            --count;
        }

        public void RemoveAt(int index)
        {
            if (Count > index && index >= 0)
            {
                var item = this[index];
                Remove(item);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}