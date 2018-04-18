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
    public class Plugin<T> : IPlugin where T : class
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
                if (value > 0)
                    order = value;
                else
                    throw new ArgumentOutOfRangeException("Must be greater than 0");
            }
        }
        private string methodName;
        private int parametersCount;
        private int ParametersCount
        {
            get
            {
                return parametersCount;
            }
            set
            {
                if (value >= 0)
                {
                    parametersCount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be equal or greater than 0");
                }
            }
        }
        private object[] methodParameters;
        private BindingFlags bindingFlags;

        private string folderName;
        private string path;
        private string fileExtension = "*.dll";
        private string[] dllFiles;
        private int stringsStartIndex;
        #endregion
        #region ctor
        public Plugin(int order
            , string folderName
            , string methodName
            , BindingFlags bindingFlags
            , int parametersCount
            , object[] parameters)
        {
            this.Order = order;
            this.folderName = folderName;
            this.methodName = methodName;
            this.ParametersCount = parametersCount;
            this.methodParameters = parameters;
            this.bindingFlags = bindingFlags;

            this.path = $@"..\..\..\{folderName}\bin\Debug\";
            dllFiles = Directory.GetFiles(path, fileExtension);
            stringsStartIndex = path.Length;
        }
        #endregion
        public List<object> Action()
        {
            List<object> list = new List<object>();
            Type interfaceType = typeof(T);
            foreach (var dll in dllFiles)
            {
                string dllName = dll.Substring(stringsStartIndex);
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path + dllName));

                try
                {
                    var typesInAssembly = assembly.GetTypes()
                        .Where(t => t.GetInterfaces().Contains(interfaceType));
                    foreach (var type in typesInAssembly
                        .Where(t => t.IsClass
                         && !t.IsAbstract))
                    {
                        list.Add(CallTypesMethod(type));
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {

                }
            }
            return list;
        }


        private object CallTypesMethod(Type type)
        {
            object instance = Activator.CreateInstance(type);
            var methods = type.GetMethods(bindingFlags);
            var method = methods.SingleOrDefault(m => m.GetParameters().Length == parametersCount
                    && methodName == m.Name);
            if (method != null)
            {
                var methodResult = CallMethod(instance, method);
                return methodResult;
            }
            return null;
        }

        /// <summary>
        ///  Calls instance's method
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private object CallMethod(object instance
            , MethodInfo method)
        {
            var invokeResult = method.Invoke(instance, methodParameters);
            return invokeResult;
        }
    }
}
