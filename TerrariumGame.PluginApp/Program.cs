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
            IPlugin<IEmployee> plugin = new Plugin<IEmployee>(1, "Say", "TerrariumGame");
            PluginActivator<IEmployee> activator = new PluginActivator<IEmployee>();
            activator.AddPlugin(plugin);
            activator.Activate();
            
            //string folderName = "TerrariumGame";
            //string path = $@"..\..\..\{folderName}\bin\Debug\";
            //string ext = "*.dll";
            //string[] dlls = Directory.GetFiles(path, ext);
            //int startIndex = path.Length;



            //foreach (var dll in dlls)
            //{
            //    string dllName = dll.Substring(startIndex);
            //    Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path + dllName));
            //    Type parentType = typeof(IEmployee);
            //    try
            //    {
            //        var typesInAssembly = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));
            //        foreach (var type in typesInAssembly)
            //        {
            //            if (!type.GetTypeInfo().IsAbstract)
            //            {
            //                object instance = Activator.CreateInstance(type);
            //                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            //                foreach (var method in methods)
            //                {
            //                    if (method.GetParameters().Length == 1)
            //                    {
            //                        var invokeResult = method.Invoke(instance, new string[] { "Hello, world!" });
            //                        Console.WriteLine(invokeResult);
            //                    }
            //                }

            //            }
            //        }
            //    }
            //    catch (ReflectionTypeLoadException ex)
            //    {

            //    }                   
            //}

            Console.ReadKey(true);
        }
    }
}
