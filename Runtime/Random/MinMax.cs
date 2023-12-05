using System;

namespace Utilities.RandomService
{
    [Serializable]
    public struct MinMax
    {
        public static MinMax Zero = new MinMax(0, 0);
        
        public MinMax(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min;
        public int Max;

        public bool IsZero()
        {
            return Min == 0 && Max == 0;
        }
        
        public static MinMax Const(int value)
        {
            return new MinMax(value, value);
        }
    }
    
}