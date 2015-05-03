using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace Radio7.Unity.Decorators
{
    public static class UnityExtensions
    {
        public static IUnityContainer RegisterDecorated(this IUnityContainer container, IEnumerable<Assembly> assemblies)
        {
            var enumeratedAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();

            var registrations = enumeratedAssemblies.FindAllRegistrations<SingletonAttribute>()
                .Union(enumeratedAssemblies.FindAllRegistrations<PerHttpRequestAttribute>())
                .Union(enumeratedAssemblies.FindAllRegistrations<TransientAttribute>())
                .ToList();

            foreach (var registration in registrations)
            {
                LifetimeManager lifetimeManager;

                switch (registration.LifeStyle)
                {
                    case LifeStyle.Singleton:
                        lifetimeManager = new ContainerControlledLifetimeManager();
                        break;
                    case LifeStyle.PerHttpRequest:
                        // ripped out of the unity.mvc source
                        lifetimeManager = new PerRequestLifetimeManager();
                        break;
                    case LifeStyle.Transient:
                        lifetimeManager = new TransientLifetimeManager();
                        break;
                    default:
                        // default lifestyle of transient
                        lifetimeManager = new TransientLifetimeManager();
                        break;
                }

                foreach (var interfaceType in registration.InterfaceTypes)
                {
                    container.RegisterType(interfaceType, registration.Instance, registration.Name, lifetimeManager);
                }
            }

            return container;
        }
    }
}
