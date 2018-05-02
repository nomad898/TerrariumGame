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
                    if (!classDelegates.ContainsKey(typeof(MessageHandler)))
                    {
                        classDelegates.Add(typeof(MessageHandler), changedHandler);
                    }
                    changedHandler += value;
                }
            }
            remove
            {
                lock (this)
                {
                    changedHandler -= value;
                }
            }
        }
        private MessageHandler showedHandler;
        public event MessageHandler OnShowed
        {
            add
            {
                lock (this)
                {
                    if (!classDelegates.ContainsKey(typeof(MessageHandler)))
                    {
                        classDelegates.Add(typeof(MessageHandler), showedHandler);
                    }
                    showedHandler += value;
                }
            }
            remove
            {
                lock (this)
                {
                    showedHandler -= value;
                }
            }
        }
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

        private Dictionary<Type, Delegate> classDelegates = new Dictionary<Type, Delegate>();

        public void UnhandleAllDelegates()
        {
            foreach (var d in classDelegates.Keys)
            {

            }
        }

    }
}
