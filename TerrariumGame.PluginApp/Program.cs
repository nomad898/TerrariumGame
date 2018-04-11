using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.PluginInterfaces;

namespace TerrariumGame.PluginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly clPath = Assembly.LoadFile(@"C:\Users\Amirzhan_Alimov\Source\Repos\TerrariumGame\TerrariumGame.PluginLibrary\bin\Debug\TerrariumGame.PluginLibrary.dll");

            Type parentType = typeof(IPlugin);

            var x = clPath.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));

            foreach (var item in x)
            {
                object instance = Activator.CreateInstance(item);
                PropertyInfo prop = item.GetProperty("Order");
                prop.SetValue(instance, 5);

                Console.WriteLine("xxx" + prop.GetValue(instance));
            }   
            
            Console.ReadKey(true);
        }        
    }
}
