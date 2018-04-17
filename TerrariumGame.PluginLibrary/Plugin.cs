using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.PluginInterfaces;

namespace TerrariumGame.PluginLibrary
{
    public class Plugin<T> where T : class, IPlugin<T>
    {
        #region Fields
        private int order;
        public int Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        private string folderName;
        private string path;
        private string fileExtension = "*.dll";
        private string[] dllFiles;
        private int stringsStartIndex;
        #endregion
        #region ctor
        public Plugin(string folderName)
        {
            this.folderName = folderName;
            this.path = $@"..\..\..\{folderName}\bin\Debug\";
            dllFiles = Directory.GetFiles(path, fileExtension);
            stringsStartIndex = path.Length;
        }
        #endregion
        public void Action(string methodName)
        {
            foreach (var dll in dllFiles)
            {
                string dllName = dll.Substring(stringsStartIndex);
                Assembly assembly = Assembly.LoadFile(Path.GetFileName(path + dllName));
                Type interfaceType = typeof(T);
                List<object> list = new List<object>();
                try
                {
                    var typesInAssembly = assembly.GetTypes()
                        .Where(t => t.GetInterfaces().Contains(interfaceType));
                    foreach (var type in typesInAssembly)
                    {
                        if (type.GetTypeInfo().IsClass &&
                            !type.GetTypeInfo().IsAbstract)
                        {
                            list.Add(CallTypesMethod(type, methodName
                                , BindingFlags.NonPublic | BindingFlags.Instance));                            
                        }
                    }
                    return list;
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Console.WriteLine(ex.Message);                    
                }                
            }
        } 
            

        private object CallTypesMethod(Type type, string methodName, BindingFlags bindingFlags)
        {
            object instance = Activator.CreateInstance(type);
            var methods = type.GetMethods(bindingFlags);
            foreach (var method in methods)
            {
                var methodResult = CallMethod(instance, method, methodName);
                if (methodResult != null)
                {
                    return methodResult;
                }
            }
            return null;
        }

        private object CallMethod(object instance, MethodInfo method, string methodName)
        {
            if (method.GetParameters().Length == 1
                && method.Name == methodName)
            {
                var invokeResult = method.Invoke(instance, new string[]
                {
                        "Hello, world!"
                });
                return invokeResult;
            }
            else return null;
        }


        //private void Method()
        //{
        //    string folderName = "TerrariumGame";
        //    string path = $@"..\..\..\{folderName}\bin\Debug\";
        //    string ext = "*.dll";
        //    string[] dlls = Directory.GetFiles(path, ext);
        //    int startIndex = path.Length;



        //    foreach (var dll in dlls)
        //    {
        //        string dllName = dll.Substring(startIndex);
        //        Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path + dllName));
        //        Type parentType = typeof(IEmployee);
        //        try
        //        {
        //            var typesInAssembly = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(parentType));
        //            foreach (var type in typesInAssembly)
        //            {
        //                if (!type.GetTypeInfo().IsAbstract)
        //                {
        //                    object instance = Activator.CreateInstance(type);
        //                    var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        //                    foreach (var method in methods)
        //                    {
        //                        if (method.GetParameters().Length == 1)
        //                        {
        //                            var invokeResult = method.Invoke(instance, new string[] { "Hello, world!" });
        //                            Console.WriteLine(invokeResult);
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //        catch (ReflectionTypeLoadException ex)
        //        {

        //        }
        //    }
        //}

    }
}
