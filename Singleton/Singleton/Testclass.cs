using System;
using Radio7.Unity.Decorators;

namespace Singleton
{
    public interface IEcho
    {
        void Echo(string message);
    }


    public interface IEchoSingleton
    {
        void Echo(string message);
    }

    [Singleton]
    public class IsASingleton : IEchoSingleton
    {

        private int _sharedState = 0;

        public void Echo(string message)
        {
            Console.WriteLine("Count: {0}, Message: {1}", _sharedState, message);
            _sharedState++;
        }
    }

    [Transient]
    public class NotASingleton : IEcho
    {
        private int _sharedState = 0;

        public void Echo(string message)
        {
            Console.WriteLine("Count: {0}, Message: {1}", _sharedState, message);
            _sharedState++;
        }
    }
}
