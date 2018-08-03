using InterfaceLibrary.Interfaces;
using System;
using System.Reflection;
using TerrariumGame.PluginInterfaces;
using TerrariumGame.PluginLibrary;

namespace TerrariumGame.PluginApp
{
    class Program
    {
        static void Main(string[] args)
        {

            PluginActivator activator = new PluginActivator();
            IPlugin plugin1 = new Plugin<IEmployee>(1, "TerrariumGame", "Say", BindingFlags.NonPublic | BindingFlags.Instance, 1, new string[] { "Plugin 1" });
            IPlugin plugin2 = new Plugin<IEmployee>(1, "TerrariumGame", "Say", BindingFlags.NonPublic | BindingFlags.Instance, 1, new string[] { "Plugin 2" });





            activator.AddPlugin(plugin2);
            activator.AddPlugin(plugin1);
            //activator.RemovePlugin(plugin);
      
            activator.Activate();


            Console.ReadKey(true);
        }
    }
}
