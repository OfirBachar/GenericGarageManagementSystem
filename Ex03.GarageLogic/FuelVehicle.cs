using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private const string k_RemainingFuelLiters = "Remaining Fuel Liters";

        private readonly eFuelTypes r_FuelType;

        public float RemainingFuelLiters { get; set; }

        private readonly float r_MaxFuelLiters;

        public eFuelTypes FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float MaxFuelLiters
        {
            get
            {
                return r_MaxFuelLiters;
            }
        }

        public enum eFuelTypes
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler,
        }

        protected FuelVehicle(eFuelTypes i_FuelType, float i_MaxFuelLiters, float i_MaxAirPressuare, int i_NumOfWheels) : base(i_MaxAirPressuare, i_NumOfWheels)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelLiters = i_MaxFuelLiters;
        }

        public void AddFuel(float i_FuelToAdd, eFuelTypes i_FuelType)
        {
            float maxFuelToAdd = MaxFuelLiters - RemainingFuelLiters;
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException($"InValid Fuel Type - The right fuel type is: {FuelType}");
            }
            
            if (IsInputInRange(i_FuelToAdd, 0, maxFuelToAdd))
            {
                RemainingFuelLiters += maxFuelToAdd;
            }
        }

        public void checkFuelTypeInRange(int i_UserChoice)
        {
            float numberOfFuelTypes = Enum.GetValues(typeof(eFuelTypes)).Length;
            if(i_UserChoice < 1 || i_UserChoice > numberOfFuelTypes)
            {
                throw new ValueOutOfRangeException(1f, numberOfFuelTypes);
            }
        }

        protected new void InsertKeys()
        {
            base.InsertKeys();
            DataInfo.Add(k_RemainingFuelLiters);
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            switch (i_DataMember)
            {
                case k_RemainingFuelLiters:
                    float userChoiceNumber = ConvertStrToNumber(i_DataMember, i_Value);
                    if(IsInputInRange(userChoiceNumber, 0, r_MaxFuelLiters))
                    {
                        RemainingFuelLiters = userChoiceNumber;
                    }

                    break;
                default:
                    base.InsertInput(i_DataMember, i_Value);
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder(base.ToString());
            infoBuilder.AppendLine($"The Amount of Fuel is: {RemainingFuelLiters}");
            infoBuilder.AppendLine($"The Type of Fuel is: {FuelType}");
            return infoBuilder.ToString();
        }
    }
}
