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
                    if (!classDelegates.Contains(typeof(MessageHandler)))
                    {
                        classDelegates.Add(typeof(MessageHandler));
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
                    if (!classDelegates.Contains(typeof(MessageHandler)))
                    {
                        classDelegates.Add(typeof(MessageHandler));
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
        private CalcHandler addedHandler;
        public event CalcHandler OnAdded
        {
            add
            {
                lock (this)
                {
                    if (!classDelegates.Contains(typeof(CalcHandler)))
                    {
                        classDelegates.Add(typeof(CalcHandler));
                    }
                    addedHandler += value;
                }
            }
            remove
            {
                lock (this)
                {
                    addedHandler -= value;
                }
            }
        }

        private string message;

        public string Message
        {
            get
            {
                showedHandler?.Invoke("Message was called");
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
            length = (int)addedHandler?.Invoke(Message.Length);
        }

        private List<Type> classDelegates = new List<Type>();

        public void UnhandleAllDelegates()
        {
            foreach (var d in classDelegates)
            {
                var c = changedHandler.GetInvocationList()[0];
                CalcHandler.RemoveAll(changedHandler, changedHandler.GetInvocationList[0]);
                var methodList = d.GetMethods();
                methodList.Select(m => m.Name == "RemoveAll").First();
            }
        }

    }
}
