using System.Collections.Generic;
using UnityEngine;

namespace Utilities.RandomService
{
    public interface IRandomService
    {
        void Initialize(int seed);

        bool Chance(float chance);

        int Int();
        int Int(int maxValue);
        int Int(int minValue, int maxValue);
        int Int(MinMax minMax);
        int Sign();

        float Float();
        float Float(FloatMinMax minMax);
        float Float(float minValue, float maxValue);

        Vector3 PointInCircle(float radius);
        Vector3 PointOnCircleEdge(float radius);

        T Sample<T>(IList<T> elements);
        void Sample<T>(IList<T> elements, int count, List<T> destination);
        IList<T> Sample<T>(IList<T> elements, int count);
        T SampleOrDefault<T>(IList<T> elements);
        IList<T> Shuffle<T>(IList<T> source);
        void ShuffleInPlace<T>(IList<T> source);
    }
}