using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.PluginInterfaces;

namespace TerrariumGame.PluginLibrary
{
    public class Plugin : IPlugin
    {
        private int order;
        public int Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public string Action(string action)
        {
            return "";
        }
    }
}
