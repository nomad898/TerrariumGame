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

            PluginActivator activator = new PluginActivator();
            IPlugin plugin = new Plugin<IEmployee>(4, "TerrariumGame", "Say", 1, new string[] { "Hello" });
            IPlugin plugin2 = new Plugin<IEmployee>(1, "TerrariumGame", "Say", 1, new string[] { "Hello World" });





            activator.AddPlugin(plugin);
            activator.AddPlugin(plugin2);
            activator.RemovePlugin(plugin);
            activator.Activate();
            
         

            Console.ReadKey(true);
        }
    }
}
