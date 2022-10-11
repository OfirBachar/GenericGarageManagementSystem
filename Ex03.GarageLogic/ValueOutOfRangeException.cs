using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format($"InValid Choice - must be between {i_MinValue} and {i_MaxValue}.{System.Environment.NewLine}"))
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
