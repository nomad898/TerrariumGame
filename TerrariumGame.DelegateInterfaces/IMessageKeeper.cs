using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.DelegateInterfaces
{
    public delegate void MessageHandler(string message);

    public interface IMessageKeeper
    {
        event MessageHandler Showed;
        event MessageHandler Changed;

        string Message { get; set; }
    }
}
