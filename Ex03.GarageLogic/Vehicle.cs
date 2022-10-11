using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const string k_ModelNameStr = "Model Name";
        public const string k_LicensePlateStr = "License Plate";

        protected float m_RemainingPowerPercentage;

        protected Engine m_Engine;

        public abstract Engine Engine { get; protected set; }

        public Client ClientVehicle { get; set; }

        public Dictionary<string, string> DataInfo { get; set; }

        public string ModelName { get; private set; }

        public string LicensePlate { get; private set; }

        public abstract float RemainingPowerPercentage { get; protected set; }

        public List<Wheel> Wheels { get; set; }

        protected Vehicle(float i_MaxAirPressure, int i_NumOfWheels)
        {
            Wheels = new List<Wheel>(i_NumOfWheels);

            for(int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_MaxAirPressure);
                Wheels.Add(wheel);
            }

            DataInfo = new Dictionary<string, string>
                           {
                               { k_ModelNameStr, null },
                               { k_LicensePlateStr, null },
                               { Wheel.k_ManufactureNameStr, null },
                               { Wheel.k_AirPressureStr, string.Format($"Insert number between 0 and {Wheels[0].MaxAirPressure - Wheels[0].AirPressure}") }
                           };
        }

        public virtual void InsertInput(string i_DataMember, string i_Value)
        {
            switch (i_DataMember)
            {
                case k_ModelNameStr:
                    ModelName = i_Value;
                    break;
                case k_LicensePlateStr:
                    LicensePlate = i_Value;
                    break;
                case Wheel.k_ManufactureNameStr:
                    foreach(Wheel wheel in Wheels)
                    {
                        wheel.ManufactureName = i_Value;
                    }

                    break;
                case Wheel.k_AirPressureStr:
                    float userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);

                    foreach (Wheel wheel in Wheels)
                    {
                        wheel.AirPressure = userChoiceNumber;
                    }

                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();

            infoBuilder.AppendLine($"The Model is: {ModelName}");
            infoBuilder.AppendLine($"The License Plate is: {LicensePlate}");
            infoBuilder.AppendLine($"The Owner Name is: {ClientVehicle.ClientName}");
            infoBuilder.AppendLine($"The Owner phone number is: {ClientVehicle.PhoneNumber}");
            infoBuilder.AppendLine($"The vehicle status in Grage is: {ClientVehicle.VehicleStatus}");
            infoBuilder.AppendLine($"The Power Percentage left is: {RemainingPowerPercentage}%");
            infoBuilder.AppendLine($"The Vehicle status in the garage is: {ClientVehicle.VehicleStatus}");
            infoBuilder.AppendLine($"The Wheel Air Pressure is: {Wheels[0].AirPressure}");
            infoBuilder.AppendLine($"The Wheel Manufacture is: {Wheels[0].ManufactureName}");

            return infoBuilder.ToString();
        }

        public void AddPressureToMax()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.AirPressure = wheel.MaxAirPressure;
            }
        }
    }
}
