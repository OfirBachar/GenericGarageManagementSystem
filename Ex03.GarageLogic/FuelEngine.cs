using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public const string k_RemainingFuelLiters = "Remaining Fuel Liters";

        public eFuelTypes FuelType { get; }

        public enum eFuelTypes
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler,
        }

        public FuelEngine(eFuelTypes i_FuelType, float i_MaxFuelLiters) : base(i_MaxFuelLiters)
        {
            FuelType = i_FuelType;
        }

        public override void AddPowerToEngine(float i_AddPower, eFuelTypes? i_FuelType = null)
        {
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException($"InValid Fuel Type - The right fuel type is: {FuelType}");
            }

            base.AddPowerToEngine(i_AddPower, i_FuelType);
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine($"The Amount of Fuel is: {RemainingPower}");
            infoBuilder.AppendLine($"The Type of Fuel is: {FuelType}");

            return infoBuilder.ToString();
        }
    }
}
