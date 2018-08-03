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
            if (!pluginsMap.Keys.Contains(plugin.Order))
            {
                pluginsMap.Add(plugin.Order, new List<IPlugin>());
            }

            pluginsMap[plugin.Order].Add(plugin);
        }

        public void RemovePlugin(IPlugin plugin)
        {
            pluginsMap[plugin.Order].Remove(plugin);
        }

        public ICollection<ICollection<IPlugin>> GetPlugins()
        {
            return pluginsMap.Values;           
        }

        public ICollection<ICollection<IPlugin>> Activate()
        {
            foreach (var plugins in pluginsMap.Values)
            {
                foreach (var plugin in plugins)
                {
                    foreach (var result in plugin.Action())
                    {
                        if (result != null)
                            Console.WriteLine(result.ToString());
                    }
                }
            }
            return null;
        }


    }
}
