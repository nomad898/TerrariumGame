﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.Interfaces
{
    interface IManagable
    {
        int DoneWork { get; set; }
        void DoWork();
        void DoWork(IWork work);
    }
}
