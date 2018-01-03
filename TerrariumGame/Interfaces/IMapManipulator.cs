using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IMapManipulator
    {
        int HourCounter
        {
            get; set;
        }

        int MaxHour { get; }

        IMap Map { get; set; }

        IFactory Factory { get; set; }

        void ShowMap();

        void SetObjects();        
    }
}
