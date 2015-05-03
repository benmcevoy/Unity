using System;

namespace Radio7.Unity.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public abstract class RegistrationAttribute : Attribute
    {
        protected RegistrationAttribute(string name, Type interfaceType, LifeStyle lifeStyle)
        {
            LifeStyle = lifeStyle;
            Name = name;
            InterfaceType = interfaceType;
        }

        public string Name { get; private set; }
        public Type InterfaceType { get; private set; }
        public LifeStyle LifeStyle { get; private set; }
    }

    public enum LifeStyle
    {
        Transient = 0,
        PerHttpRequest,
        Singleton,
    }
}
