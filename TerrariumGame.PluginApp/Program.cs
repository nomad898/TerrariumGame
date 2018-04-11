using InterfaceLibrary.Interfaces;
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
            Assembly clPath = Assembly.LoadFile(@"C:\Users\Amirzhan_Alimov\Source\Repos\TerrariumGame\TerrariumGame\bin\Debug\TerrariumGame.dll");

            Type parentType = typeof(IWorker);

            var x = clPath.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));

            foreach (var item in x)
            {
                object instance = Activator.CreateInstance(item);

                
                MethodInfo method = item.GetMethod("Say", BindingFlags.Instance | BindingFlags.NonPublic,
        Type.DefaultBinder,
        new[] { typeof(int), typeof(int) },
        null);

                object result = method.Invoke(instance, new object[] { "Hello" });
                Console.WriteLine(result);

            }

            Console.ReadKey(true);
        }
    }
}
