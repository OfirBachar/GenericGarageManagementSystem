using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public const string k_ManufactureNameStr = "Manufacture Wheel Name";
        public const string k_AirPressureStr = "Air Pressure";

        public string ManufactureName { get; set; }

        private float m_AirPressure;

        public float AirPressure
        {
            get => m_AirPressure;
            set
            {
                if (Garage.IsInputInRange(value, 0, MaxAirPressure))
                {
                    m_AirPressure = value;
                }
            }
        }

        public float MaxAirPressure { get; set; }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }
    }
}
