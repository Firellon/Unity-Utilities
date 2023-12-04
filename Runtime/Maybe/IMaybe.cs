using System;
using UnityEngine;

namespace Utilities.Maybe
{
    public interface IMaybe<T>
    {
        bool IsPresent { get; }
        bool IsNotPresent { get; }

        public T ValueOr(T defaultValue);
        public T ValueOrDefault();

        public IMaybe<T> IfPresent(Action<T> executor);

        public IMaybe<T> IfNotPresent(Action executor);
    }
}