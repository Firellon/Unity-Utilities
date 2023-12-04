using System;

namespace Utilities.Monads
{
    internal class Just<T> : IMaybe<T>
    {
        private readonly T _value;

        public Just(T value = default)
        {
            _value = value; 
        }

        public bool IsPresent => true;
        public bool IsNotPresent => false;
        
        public T ValueOr(T defaultValue)
        {
            return _value;
        }
        
        public T ValueOrDefault()
        {
            return _value;
        }

        public IMaybe<T> IfPresent(Action<T> executor)
        {
            executor(_value);
            return this;
        }
        
        public IMaybe<T> IfNotPresent(Action executor)
        {
            return this;
        }
    }
}