using System;

namespace Utilities
{
    public static class Maybe
    {
        public static IMaybe<T> Of<T>(T content)
        {
            return new Just<T>(content);
        }
        
        public static IMaybe<T> Empty<T>()
        {
            return new Nothing<T>();
        }

        public static IMaybe<T> ToMaybe<T>(this T value)
        {
            return value == null ? Empty<T>() : Of(value);
        }
        
        public static IMaybe<T> ToMaybe<T>(this T? value) where T : struct
        {
            return value.HasValue ? Of(value.Value) : Empty<T>();
        }
        
        public static TOutput Match<TInput, TOutput>(this IMaybe<TInput> maybe, Func<TInput, TOutput> some, TOutput none)
        {
            return maybe.IsPresent ? some(maybe.ValueOrDefault()) : none;
        }
        
        public static TOutput Match<TInput, TOutput>(this IMaybe<TInput> maybe, Func<TInput, TOutput> some, Func<TOutput> none)
        {
            return maybe.IsPresent ? some(maybe.ValueOrDefault()) : none();
        }

        public static IMaybe<ValueTuple<TA, TB>> CombineIfPresent<TA, TB>(this IMaybe<TA> maybeA,IMaybe<TB> maybeB)
        {
            return maybeA.Match(
                outputA =>
                {
                    return maybeB.Match(
                        outputB => Of<ValueTuple<TA, TB>>(new ValueTuple<TA, TB>(outputA, outputB)),
                        Empty<ValueTuple<TA, TB>>());
                }, Empty<ValueTuple<TA, TB>>());
        }

        public static IMaybe<T> Flatten<T>(this IMaybe<IMaybe<T>> maybeMaybe)
        {
            return maybeMaybe.Match(maybe => maybe, Empty<T>());
        }

        public static bool IsEmptyOrEqual<T>(this IMaybe<T> maybe, T value) where T: IEquatable<T>
        {
            return maybe.Match(some => some.Equals(value), true);
        }
    }
}