using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public const string k_RemainingBatteryHoursStr = "Remaining Battery Hours";

        public ElectricEngine(float i_MaxBatteryHours) : base(i_MaxBatteryHours) { }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine($"The Amount of Battery left in Hours is: {RemainingPower}");

            return infoBuilder.ToString();
        }
    }
}
