using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoFish.Core.IOC
{
    public class ServiceProvider
    {
        public static IContainer Instance { get; private set; }

        public static void RegisterServiceLocator(IContainer locator)
        {
            if (Instance == null)
                Instance = locator;
        }

        public static T Get<T>()
        {
            var tt = typeof(T).Name;
            if (Instance == null || !Instance.IsRegistered<T>()) return default(T);
            return Instance.Resolve<T>();
        }

        public static T Get<T>(string typeName)
        {
            if (Instance.IsRegisteredWithName<T>(typeName))
                return Instance.ResolveNamed<T>(typeName);
            else
                return default(T);
        }
    }
}
