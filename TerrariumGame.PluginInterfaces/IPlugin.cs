﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.PluginInterfaces
{
    public interface IPlugin
    {
        int Order { get; set; }
        List<object> Action();
    }
}
