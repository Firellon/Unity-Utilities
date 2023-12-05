using System;

namespace Utilities.RandomService
{
    [Serializable]
    public struct FloatMinMax
    {
        public FloatMinMax(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Min;
        public float Max;

        public float Delta => Max - Min;

        public float Sample(IRandomService randomService)
        {
            return randomService.Float(Min, Max);
        }
        
        public bool InRange(float value)
        {
            return value >= Min && Max <= value;
        }
        
        public bool IsZero()
        {
            return System.Math.Abs(Min) < 0.0001f && System.Math.Abs(Max) < 0.0001f;
        }
    }
}