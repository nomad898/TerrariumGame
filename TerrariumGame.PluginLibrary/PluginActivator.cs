using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.PluginInterfaces;

namespace TerrariumGame.PluginLibrary
{
    public class PluginActivator
    {
        List<IPlugin> plugins = new List<IPlugin>();

        public void AddPlugin(IPlugin plugin)
        {            
            plugins.Add(plugin);
            SortByOrder();
        }

        public void RemovePlugin(IPlugin plugin)
        {
            plugins.Remove(plugin);
            SortByOrder();
        }

        public void Activate()
        {
            if (plugins.Count > 0)
                foreach (var plugin in plugins)
                {
                    foreach (var item in plugin.Action())
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
        }

        /// <summary>
        ///     Bubble sorting
        /// </summary>
        private void SortByOrder()
        {
            IPlugin temp;

            for (int i = 0; i < plugins.Count; i++)
            {
                for (int j = 0; j < plugins.Count - 1; j++)
                {
                    if (plugins[j].Order > plugins[i + 1].Order)
                    {
                        temp = plugins[j + 1];
                        plugins[j + 1] = plugins[j];
                        plugins[j] = temp;
                    }
                }
            }
        }
    }
}
