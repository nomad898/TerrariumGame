using InterfaceLibrary.Interfaces;
using System;
using TerrariumGame.PluginInterfaces;
using TerrariumGame.PluginLibrary;

namespace TerrariumGame.PluginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlugin plugin = new Plugin<IEmployee>(1, "Say", "TerrariumGame");
            PluginActivator activator = new PluginActivator();
            activator.AddPlugin(plugin);
            activator.Activate();
            
         

            Console.ReadKey(true);
        }
    }
}
