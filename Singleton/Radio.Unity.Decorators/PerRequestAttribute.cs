using System;

namespace Radio7.Unity.Decorators
{
    public class PerHttpRequestAttribute : RegistrationAttribute
    {
        public PerHttpRequestAttribute()
            : base(null, null, LifeStyle.PerHttpRequest)
        {
        }

        public PerHttpRequestAttribute(string name)
            : base(name, null, LifeStyle.PerHttpRequest)
        {
        }

        public PerHttpRequestAttribute(Type interfaceType)
            : base(null, interfaceType, LifeStyle.PerHttpRequest)
        {
        }
    }
}
