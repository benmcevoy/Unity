using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace Radio7.Unity.Decorators
{
    public class Registration
    {
        public Registration(Type instance, string name, IEnumerable<Type> interfaceTypes, LifeStyle lifeStyle)
        {
            LifeStyle = lifeStyle;
            Instance = instance;
            Name = name ?? WithName.Default(instance);
            InterfaceTypes = interfaceTypes ?? Enumerable.Empty<Type>();
        }

        public Type Instance { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Type> InterfaceTypes { get; private set; }

        public LifeStyle LifeStyle { get; private set; }
    }
}
