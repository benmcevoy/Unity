using System;
using System.Reflection;
using Microsoft.Practices.Unity;
using Radio7.Unity.Decorators;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

           // container.RegisterType<IEcho, NotASingleton>(new PerResolveLifetimeManager());

            container.RegisterDecorated(new [] {Assembly.GetExecutingAssembly()});

            var notASinglton = container.Resolve<IEcho>();

            notASinglton.Echo("hopefully transient");
            notASinglton.Echo("hopefully transient");
            notASinglton.Echo("hopefully transient");
            notASinglton.Echo("hopefully transient");

            notASinglton = container.Resolve<IEcho>();
            notASinglton.Echo("hopefully transient");
            notASinglton.Echo("hopefully transient");

            var isASingleton = container.Resolve<IEchoSingleton>();

            isASingleton.Echo("hopefully singleton");
            isASingleton.Echo("hopefully singleton");
            isASingleton.Echo("hopefully singleton");
            isASingleton.Echo("hopefully singleton");


            isASingleton = container.Resolve<IEchoSingleton>();
            isASingleton.Echo("hopefully singleton");
            isASingleton.Echo("hopefully singleton");


            var isASingletonClass = container.Resolve<IsASingleton>();
            isASingletonClass.Echo("hopefully singleton");
            isASingletonClass.Echo("hopefully singleton");
            isASingletonClass.Echo("hopefully singleton");
            isASingletonClass.Echo("hopefully singleton");

            isASingletonClass = container.Resolve<IsASingleton>();
            isASingletonClass.Echo("hopefully singleton");
            isASingletonClass.Echo("hopefully singleton");


            Console.ReadKey();
        }
    }
}
