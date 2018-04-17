using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
            //    Assembly clPath = Assembly.LoadFile(@"C:\Users\Amirzhan_Alimov\Source\Repos\TerrariumGame\TerrariumGame\bin\Debug\TerrariumGame.dll");

            //    Type parentType = typeof(IWorker);

            //    var x = clPath.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));

            //    foreach (var item in x)
            //    {
            //        object instance = Activator.CreateInstance(item);


            //        MethodInfo method = item.GetMethod("Say", BindingFlags.Instance | BindingFlags.NonPublic,
            //Type.DefaultBinder,
            //new[] { typeof(int), typeof(int) },
            //null);

            //        object result = method.Invoke(instance, new object[] { "Hello" });
            //        Console.WriteLine(result);

            //    }

            string folderName = "TerrariumGame";
            string path = $@"..\..\..\{folderName}\bin\Debug\";
            string ext = "*.dll";
            string[] dlls = Directory.GetFiles(path, ext);
            int startIndex = path.Length;



            foreach (var dll in dlls)
            {
                string dllName = dll.Substring(startIndex);
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path + dllName));
                Type parentType = typeof(IEmployee);
                try
                {
                    var typesInAssembly = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));
                    foreach (var type in typesInAssembly)
                    {
                        if (!type.GetTypeInfo().IsAbstract)
                        {
                            object instance = Activator.CreateInstance(type);
                            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                            foreach (var method in methods)
                            {
                                if (method.GetParameters().Length == 1)
                                {
                                    var invokeResult = method.Invoke(instance, new string[] { "Hello, world!" });
                                    Console.WriteLine(invokeResult);
                                }
                            }

                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {

                }                   
            }

            Console.ReadKey(true);
        }
    }
}
