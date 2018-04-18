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

        public void Activate()
        {
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
