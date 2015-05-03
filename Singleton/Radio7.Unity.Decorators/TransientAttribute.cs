using System;

namespace Radio7.Unity.Decorators
{
    public class TransientAttribute : RegistrationAttribute
    {
        public TransientAttribute()
            : base(null, null, LifeStyle.Transient)
        {
        }

        public TransientAttribute(string name)
            : base(name, null, LifeStyle.Transient)
        {
        }

        public TransientAttribute(Type interfaceType)
            : base(null, interfaceType, LifeStyle.Transient)
        {
        }
    }
}