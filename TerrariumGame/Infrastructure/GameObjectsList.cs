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
        #region Fields
        private int indexCounter = 0;
        private int count = 0;

        #region Nodes
        /// <summary>
        ///     The first element in the list
        /// </summary>
        private Node head = null;

        private Node Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }

        /// <summary>
        ///     The last element the list
        /// </summary>
        private Node tail = null;

        private Node Tail
        {
            get
            {
                tail = Head;
                if (tail == null)
                {
                    return null;
                }
                while (tail.Next != null)
                {
                    tail = tail.Next;
                }
                return tail;
            }
        }

        private class Node
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
                    if (value >= 0)
                    {
                        index = value;
                    }
                }
            }

            public Node() { }

            public Node(IGameObject item)
            {
                Data = item;
            }
        }
        #endregion
        #region Elements
        /// <summary>
        ///     Returns the first item.
        /// </summary>
        public IGameObject First
        {
            get
            {
                return Head.Data;
            }
            private set
            {
                Head.Data = value;
            }
        }

        /// <summary>
        ///     Returns the last item.
        /// </summary>
        public IGameObject Last
        {
            get
            {
                return Tail.Data;
            }
            private set
            {
                Tail.Data = value;
            }
        }

        public IGameObject this[int index]
        {
            get
            {
                if (Count > index && index >= 0)
                {
                    for (Node current = Head; current != null;
                        current = current.Next)
                    {
                        if (current.Index == index)
                        {
                            return current.Data;
                        }
                    }
                }
                throw new ArgumentOutOfRangeException(
                    string.Format("Element with index {0} does not exist", index));
            }
            set
            {
                if (Count > index && index >= 0)
                {
                    for (Node current = Head; current != null;
                       current = current.Next)
                    {
                        if (current.Index == index)
                        {
                            current.Data = value;
                            return;
                        }
                    }
                }
                throw new ArgumentOutOfRangeException(
                   string.Format("Element with index {0} does not exist", index));
            }
        }
        #endregion
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
        #endregion
        /// <summary>
        ///     Add a new item to the list.
        /// </summary>
        /// <param name="item">Game object</param>
        /// 
        public void Add(IGameObject item)
        {
            if (Head == null)
            {
                Head = new Node(item);
                Head.Index = indexCounter;
                
            }
            else
            {
                AddToEnd(item);
            }
            indexCounter++;
            count++;
        }
      
        /// <summary>
        ///     Add a new item to the end of the list.
        /// </summary>
        /// <param name="item">Game object</param>
        private void AddToEnd(IGameObject item)
        {
            Node last = Tail;
            Node newNode = new Node(item);
            last.Next = newNode;
            newNode.Index = indexCounter;
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
                for (Node current = Head; current != null;
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
                Node current = Head;
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
                for (Node current = Head; current != null;
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
            for (Node current = Head; current != null;
                current = current.Next, arrayIndex++, index++, count--)
            {
                if (count == 0)
                {
                    break;
                }
                array[arrayIndex] = this[index];
            }
        }

        /// <summary>
        ///     Copy items to new list.
        /// </summary>
        /// <returns></returns>
        public List<IGameObject> ToList()
        {
            List<IGameObject> list = new List<IGameObject>();
            foreach (var el in this)
            {
                list.Add(el);
            }
            return list;
        }

        public IEnumerator<IGameObject> GetEnumerator()
        {
            Node current = Head;
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
            Node current = Head;
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

        /// <summary>
        ///     Put new item to certain index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, IGameObject item)
        {
            if (Count > index && index >= 0)
            {
                var current = Head;
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
                if (Head.Data == item)
                {
                    DeleteFirstItem(ref current, item);
                }
                else
                {
                    DeleteNoFirstItem(ref current, item);
                }
                IndexAndCountDecrement(current);
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
            Head = Head.Next;
            current = Head;
        }
        /// <summary>
        ///     Delete not the first item.
        /// </summary>
        /// <param name="current">Current node</param>
        /// <param name="item">item to remove</param>
        private void DeleteNoFirstItem(ref Node current, IGameObject item)
        {
            current = Head;
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
        private void IndexAndCountDecrement(Node current)
        {
            while (current != null)
            {                          
                current.Index--;
                current = current.Next;
            }
            indexCounter--;
            count--;
        }

        /// <summary>
        ///     Remove item by index.
        /// </summary>
        /// <param name="index"></param>
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