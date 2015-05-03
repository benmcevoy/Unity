using System;

namespace Radio7.Unity.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonAttribute : RegistrationAttribute
    {
        public SingletonAttribute()
            : base(null, null, LifeStyle.Singleton)
        {
        }

        public SingletonAttribute(string name)
            : base(name, null, LifeStyle.Singleton)
        {
        }

        public SingletonAttribute(Type interfaceType)
            : base(null, interfaceType, LifeStyle.Singleton)
        {
        }
    }
}
