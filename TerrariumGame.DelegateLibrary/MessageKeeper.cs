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
        public event MessageHandler Changed;
        public event MessageHandler Showed;

        private string message;

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                Changed?.Invoke($"Old value - {message}");
                this.message = value;
                Changed?.Invoke($"Message was changed - {message}");
            }
        }


    }
}
