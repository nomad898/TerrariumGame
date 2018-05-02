using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.DelegateInterfaces
{
    public delegate void MessageHandler(string message);
    public delegate int CalcHandler(int value);
    
    public interface IMessageKeeper
    {
        event MessageHandler OnShowed;
        event MessageHandler OnChanged;
        event CalcHandler OnAdded;
        string Message { get; set; }

        void Add(string addString, out int length);
        void UnhandleAllDelegates();
    }
}
