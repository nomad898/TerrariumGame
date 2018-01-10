﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IMapManipulator
    {
        int HourCounter
        {
            get; set;
        }

        int MaxHour { get; }

        IMap Map { get; set; }

        IGameObjectFactory GameObjectFactory { get; set; }

        void ShowMap();

        void SetObjects();        
    }
}