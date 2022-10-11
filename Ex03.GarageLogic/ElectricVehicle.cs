using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        public float RemainingBatteryHours { get; set; }

        public float MaxBatteryHours { get; set; }

        public void ChargeBattery(float i_TimeToCharge)
        {
            float maxTimeToCharge = MaxBatteryHours - RemainingBatteryHours;

            if (i_TimeToCharge > maxTimeToCharge || i_TimeToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, maxTimeToCharge);
            }

            RemainingBatteryHours += i_TimeToCharge;
        }
    }
}
