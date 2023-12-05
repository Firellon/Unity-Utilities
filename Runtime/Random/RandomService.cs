using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities.RandomService;

namespace Utilities.Random
{
    public class RandomService : IRandomService
    {
        private readonly List<int> sampleBuffer = new List<int>();

        private System.Random random;
        public static RandomService Instance { get; private set; }

        public RandomService() : this(DateTime.UtcNow.Millisecond)
        {
        }

        public RandomService(int seed)
        {
            Initialize(seed);
            Instance = this;
        }

        public bool Chance(float chance)
        {
            return Float() < chance;
        }

        public int Int()
        {
            return random.Next();
        }

        public int Int(int maxValue)
        {
            return random.Next(maxValue);
        }

        public int Int(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public int Int(MinMax minMax)
        {
            return random.Next(minMax.Min, minMax.Max);
        }

        public int Sign()
        {
            return Int(0, 2) * 2 - 1;
        }

        public float Float()
        {
            return (float) random.NextDouble();
        }

        public float Float(FloatMinMax minMax)
        {
            return Float(minMax.Min, minMax.Max);
        }

        public float Float(float minValue, float maxValue)
        {
            return minValue + (maxValue - minValue) * Float();
        }

        public Vector3 PointInCircle(float radius)
        {
            return UnityEngine.Random.insideUnitCircle.normalized * radius;
        }

        public Vector3 PointOnCircleEdge(float radius)
        {
            var vector2 = UnityEngine.Random.insideUnitCircle.normalized * radius;
            return new Vector3(vector2.x, vector2.y);
        }

        public T Sample<T>(IList<T> elements)
        {
            return elements[Int(elements.Count)];
        }

        public IList<T> Sample<T>(IList<T> elements, int count)
        {
            var result = new List<T>(count);
            Sample(elements, count, result);
            return result;
        }

        public void Sample<T>(IList<T> elements, int count, List<T> destination)
        {
            if (count == 0)
                return;
            if (elements.Count < count)
                throw new ArgumentException(
                    $"argument {nameof(count)} must be lower or equal than length od {nameof(elements)}");

            sampleBuffer.Clear();
            for (var i = 0; i < elements.Count; i++)
                sampleBuffer.Add(i);

            ShuffleInPlace(sampleBuffer);

            destination.Clear();
            for (var i = 0; i < count; i++)
                destination.Add(elements[sampleBuffer[i]]);
            sampleBuffer.Clear();
        }

        public T SampleOrDefault<T>(IList<T> elements)
        {
            return elements.Count == 0 ? default : Sample(elements);
        }

        public IList<T> Shuffle<T>(IList<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var length = source.Count;

            var buffer = new T[length];
            source.CopyTo(buffer, 0);
            for (var i = 0; i < length; i++)
            {
                var j = Int(i, length);
                (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
            }

            return buffer;
        }

        public void ShuffleInPlace<T>(IList<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var length = source.Count;

            for (var i = 0; i < length; i++)
            {
                var j = Int(i, length);
                (source[i], source[j]) = (source[j], source[i]);
            }
        }

        public void Initialize(int seed)
        {
            random = new System.Random(seed);
        }
    }
}