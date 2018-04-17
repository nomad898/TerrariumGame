using System;
using System.Collections.Generic;
using System.IO;
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
            string[] dlls = Directory.GetFiles(@"..\..\TerrariumGame\bin\Debug\'");
            foreach (var item in dlls)
            {
                Console.WriteLine(item);
            }
            var dllsPath = new FileInfo(@"..\..\TerrariumGame\bin\Debug\'");
            return "";
        }
    }
}
