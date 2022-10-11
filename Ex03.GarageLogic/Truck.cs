using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const string k_IsColdContentTransportStr = "Is Cold Content Transport";
        private const string k_ContentCapacityStr = "Content Capacity";
        public const FuelEngine.eFuelTypes k_FuelType = FuelEngine.eFuelTypes.Soler;
        public const float k_MaxFuelLiters = 120;
        public const int k_NumberOfWheels = 16;
        public const float k_MaxAirPressureWheel = 24;

        public bool IsColdContentTransport { get; set; }

        public float ContentCapacity { get; set; }

        public override Engine Engine
        {
            get => m_Engine;
            protected set => m_Engine = value;
        }

        public override float RemainingPowerPercentage
        {
            get => (Engine.RemainingPower * 100) / Engine.MaxPower;
            protected set => m_RemainingPowerPercentage = value;
        }

        public Truck(FuelEngine.eFuelTypes i_FuelType, float i_MaxFuelLiters, float i_MaxAirPressure, int i_NumOfWheels) : base(i_MaxAirPressure, i_NumOfWheels)
        {
            m_Engine = new FuelEngine(i_FuelType, i_MaxFuelLiters);
            DataInfo.Add(k_IsColdContentTransportStr, "Insert 1 for YES or 2 for NO");
            DataInfo.Add(k_ContentCapacityStr, null);
            DataInfo.Add(FuelEngine.k_RemainingFuelLiters, string.Format($"insert number between 0 and {k_MaxFuelLiters - m_Engine.RemainingPower}"));
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            float userChoiceNumber;

            switch (i_DataMember)
            {
                case k_IsColdContentTransportStr:
                    IsColdContentTransport = i_Value == "1";
                    break;
                case k_ContentCapacityStr:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    ContentCapacity = userChoiceNumber;
                    break;
                case FuelEngine.k_RemainingFuelLiters:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    Engine.RemainingPower = userChoiceNumber;
                    break;
                default:
                    base.InsertInput(i_DataMember, i_Value);
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder(base.ToString());
            string isColdContentIndication = IsColdContentTransport == true ? "" : "not";

            infoBuilder.AppendLine($"The Truck is {isColdContentIndication} Transport Cold Content");
            infoBuilder.AppendLine($"The Content Capacity is: {ContentCapacity}");
            infoBuilder.AppendLine(Engine.ToString());

            return infoBuilder.ToString();
        }
    }
}