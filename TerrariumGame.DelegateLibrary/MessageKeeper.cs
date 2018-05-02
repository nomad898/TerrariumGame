using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.DelegateInterfaces;

namespace TerrariumGame.DelegateLibrary
{
    public class MessageKeeper : IMessageKeeper
    {
        private MessageHandler changedHandler;
        public event MessageHandler OnChanged
        {
            add
            {
                lock (this)
                {
                    changedHandler += value;
                    delegatesList.Add(value);
                }
            }
            remove
            {
                lock (this)
                {
                    changedHandler -= value;
                    delegatesList.Remove(value);
                }
            }
        }
        public event MessageHandler OnShowed;
        public event CalcHandler OnAdded;

        private string message;

        public string Message
        {
            get
            {
                OnShowed?.Invoke("Message was called");
                return this.message;
            }
            set
            {
                changedHandler?.Invoke($"Old value - {message}");
                this.message = value;
                changedHandler?.Invoke($"Message was changed - {message}");
            }
        }

        public void Add(string addString, out int length)
        {
            Message += addString;
            length = (int)OnAdded?.Invoke(Message.Length);
        }

        private List<Delegate> delegatesList = new List<Delegate>();

        public void UnhandleAllDelegates()
        {
            foreach (var d in delegatesList)
            {
               
            }
        }

    }
}
