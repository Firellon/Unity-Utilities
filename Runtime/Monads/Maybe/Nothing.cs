using System;

namespace Utilities.Monads
{
    internal class Nothing<T> : IMaybe<T>
    {
        public bool IsPresent => false;
        public bool IsNotPresent => true;
        
        public T ValueOr(T defaultValue)
        {
            return defaultValue;
        }
        
        public T ValueOrDefault()
        {
            return default;
        }

        public IMaybe<T> IfPresent(Action<T> executor)
        {
            return this;
        }
        
        public IMaybe<T> IfNotPresent(Action executor)
        {
            executor();
            
            return this;
        }
    }
}