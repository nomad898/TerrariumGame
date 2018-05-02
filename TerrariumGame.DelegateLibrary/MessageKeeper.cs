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
                    this.changedHandler -= changedHandler;
                    changedHandler += value;
                    if (!classDelegates.ContainsKey(changedHandler))
                    {
                        classDelegates.Add(changedHandler, new List<Delegate>());
                    }
                    if (classDelegates[changedHandler].Capacity >= 0)
                    {
                        classDelegates[changedHandler].Add(value);
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
                    this.showedHandler -= showedHandler;
                    showedHandler += value;
                    if (!classDelegates.ContainsKey(showedHandler))
                    {
                        classDelegates.Add(showedHandler, new List<Delegate>());
                    }
                    if (classDelegates[showedHandler].Capacity >= 0)
                    {
                        classDelegates[showedHandler].Add(value);
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
                    this.addedHandler -= addedHandler;
                    addedHandler += value;
                    if (!classDelegates.ContainsKey(addedHandler))
                    {
                        classDelegates.Add(addedHandler, new List<Delegate>());
                    }
                    if (classDelegates[addedHandler].Capacity >= 0)
                    {
                        classDelegates[addedHandler].Add(value);
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

        private Dictionary<Delegate, List<Delegate>> classDelegates = new Dictionary<Delegate, List<Delegate>>();

        public void UnhandleAllDelegates()
        {
            for (int i = 0; i < classDelegates.Count; i++)
            {
                Console.WriteLine("------------------");
                var x = classDelegates.Keys.ElementAt(i);
                //foreach (var item in x.)
                //{
                //}
                Console.WriteLine("------------------");
            }
        }

    }
}
