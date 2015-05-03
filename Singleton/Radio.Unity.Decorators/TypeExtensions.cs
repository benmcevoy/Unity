using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Radio7.Unity.Decorators
{
    public static class TypeExtensions
    {
        private static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static IEnumerable<Type> Scan()
        {
            return Scan(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static IEnumerable<Type> Scan(this Assembly assembly)
        {
            return Scan(new [] { assembly });
        }

        public static IEnumerable<Type> Scan(this IEnumerable<Assembly> assemblies)
        {
            var enumeratedAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();

            return enumeratedAssemblies.SelectMany(assembly => assembly.GetLoadableTypes());
        }

        public static IEnumerable<Type> ScanFor(this IEnumerable<Assembly> assemblies, Type typeToScanFor)
        {
            var types = assemblies
                .SelectMany(assembly => assembly.GetLoadableTypes())
                .Where(t => typeToScanFor.IsAssignableFrom(t) && t.IsClass)
                .ToList();

            return types;
        }

        public static IEnumerable<Type> ScanForAttribute<T>(this IEnumerable<Assembly> assemblies)
            where T: Attribute
        {
            var attributeType = typeof(T);

            var types = assemblies
                .SelectMany(assembly => assembly.GetLoadableTypes())
                .Where(t => t.GetCustomAttributes(attributeType, false).Any() && t.IsClass)
                .ToList();

            return types;
        }

        public static IEnumerable<Registration> FindAllRegistrations<T>(this IEnumerable<Assembly> assemblies)
            where T : RegistrationAttribute
        {
            var singletons = assemblies.ScanForAttribute<T>();

            foreach (var singleton in singletons)
            {
                var meta = singleton.GetCustomAttribute<T>();
                var interfaces = new List<Type> { singleton };

                if (meta.InterfaceType == null)
                {
                    interfaces = singleton.GetInterfaces().ToList();
                }

                yield return new Registration(singleton, meta.Name, interfaces, meta.LifeStyle);
            }
        }
    }
}
