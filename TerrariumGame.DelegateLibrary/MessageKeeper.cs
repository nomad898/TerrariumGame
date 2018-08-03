using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.DelegateInterfaces;

namespace TerrariumGame.DelegateLibrary
{
    public class MessageKeeper : IMessageKeeper
    {
        public MessageKeeper()
        {
            handlers.Add("OnChanged", null);
            handlers.Add("OnShowed", null);
            handlers.Add("OnAdded", null);
        }

        public event MessageHandler OnChanged
        {
            add
            {
                lock (this)
                {
                    handlers["OnChanged"] = (MessageHandler)handlers["OnChanged"] + value;
                }
            }
            remove
            {
                lock (this)
                {
                    handlers["OnChanged"] = (MessageHandler)handlers["OnChanged"] - value;
                }
            }
        }
        public event MessageHandler OnShowed
        {
            add
            {
                lock (this)
                {
                    handlers["OnShowed"] = (MessageHandler)handlers["OnShowed"] + value;
                }
            }
            remove
            {
                lock (this)
                {
                    handlers["OnShowed"] = (MessageHandler)handlers["OnShowed"] - value;
                }
            }
        }
        public event CalcHandler OnAdded
        {
            add
            {
                lock (this)
                {
                    handlers["OnAdded"] = (CalcHandler)handlers["OnAdded"] + value;
                }
            }
            remove
            {
                lock (this)
                {
                    handlers["OnAdded"] = (CalcHandler)handlers["OnAdded"] - value;
                }
            }
        }

        private string message;

        public string Message
        {
            get
            {
                MessageHandler showedHandler;
                if ((showedHandler = (MessageHandler)handlers["OnShowed"]) != null)
                {
                    showedHandler?.Invoke("Message was called");
                }
                return this.message;
            }
            set
            {
                MessageHandler changedHandler;
                if ((changedHandler = (MessageHandler)handlers["OnChanged"]) != null)
                {
                    changedHandler?.Invoke($"Old value - {message}");
                }
                this.message = value;
                if ((changedHandler = (MessageHandler)handlers["OnChanged"]) != null)
                {
                    changedHandler?.Invoke($"Message was changed - {message}");
                }
            }
        }

        public void Add(string addString, out int length)
        {
            CalcHandler addedHandler;
            length = 0;
            if ((addedHandler = (CalcHandler)handlers["OnAdded"]) != null)
            {
                Message += addString;
                length = (int)addedHandler?.Invoke(Message.Length);
            }
        }

        private Dictionary<string, Delegate> handlers = new Dictionary<string, Delegate>();

        public void UnhandleAllDelegates()
        {
            for (int i = 0; i < handlers.Keys.Count; i++)
            {
                handlers[handlers.Keys.ElementAt(i)] = null;
            }
        }
    }
}
