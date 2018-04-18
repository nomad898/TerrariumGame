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
        IDictionary<int, ICollection<IPlugin>> pluginsMap
            = new SortedDictionary<int, ICollection<IPlugin>>();

        public void AddPlugin(IPlugin plugin)
        {
            ICollection<IPlugin> pluginsList;
            if (!pluginsMap.Keys.Contains(plugin.Order))
            {
                pluginsMap.Add(plugin.Order, new List<IPlugin>());
            }
            pluginsList = pluginsMap[plugin.Order];

            pluginsList.Add(plugin);
        }

        public void RemovePlugin(IPlugin plugin)
        {
            ICollection<IPlugin> pluginsList = pluginsMap[plugin.Order]; 
            pluginsList.Remove(plugin);
        }

        public void Activate()
        {
            if (pluginsMap.Keys.Count > 0)
                foreach (var plugin in pluginsMap.Values)
                {
                    foreach (var item in plugin)
                    {
                        item.Action().ForEach(delegate (object result)
                        {
                            Console.WriteLine(result.ToString());
                        });
                    }
                }
        }


    }
}
