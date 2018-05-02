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
                        classDelegates.Add(typeof(MessageHandler), new List<Delegate>());
                    }
                    changedHandler += value;
                    if (classDelegates[typeof(MessageHandler)].Capacity >= 0)
                    {
                        classDelegates[typeof(MessageHandler)].Add(value);
                    }
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
                        classDelegates.Add(typeof(MessageHandler), new List<Delegate>());
                    }
                    showedHandler += value;
                    if (classDelegates[typeof(MessageHandler)].Capacity >= 0)
                    {
                        classDelegates[typeof(MessageHandler)].Add(value);
                    }
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
                    if (!classDelegates.ContainsKey(typeof(CalcHandler)))
                    {
                        classDelegates.Add(typeof(CalcHandler), new List<Delegate>());
                    }
                    addedHandler += value;
                    if (classDelegates[typeof(CalcHandler)].Capacity >= 0)
                    {
                        classDelegates[typeof(CalcHandler)].Add(value);
                    }
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

        private Dictionary<Type, List<Delegate>> classDelegates = new Dictionary<Type, List<Delegate>>();

        public void UnhandleAllDelegates()
        {
            foreach (var d in classDelegates.Keys)
            {                
                var par = classDelegates[d];
               
                foreach (var item in par)
                {
                    Console.WriteLine(item.Method.Name);
                }
                //var methodList = d.GetMethods();
                //methodList.Select(m => m.Name == "RemoveAll").First();
            }
        }

    }
}
