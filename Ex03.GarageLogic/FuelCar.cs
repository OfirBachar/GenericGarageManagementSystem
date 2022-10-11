using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        public const FuelEngine.eFuelTypes k_FuelType = FuelEngine.eFuelTypes.Octan95;
        public const float k_MaxFuelLiters = 38;

        public override float RemainingPowerPercentage
        {
            get => (Engine.RemainingPower * 100) / Engine.MaxPower;
            protected set => m_RemainingPowerPercentage = value;
        }

        public override Engine Engine
        {
            get => m_Engine;
            protected set => m_Engine = value;
        }

        public FuelCar(FuelEngine.eFuelTypes i_FuelType, float i_MaxFuelLiters, float i_MaxAirPressure, int i_NumOfWheels) : base(i_MaxAirPressure, i_NumOfWheels)
        {
            m_Engine = new FuelEngine(i_FuelType, i_MaxFuelLiters);
            DataInfo.Add(FuelEngine.k_RemainingFuelLiters, string.Format($"insert number between 0 and {k_MaxFuelLiters - m_Engine.RemainingPower}"));
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            switch (i_DataMember)
            {
                case FuelEngine.k_RemainingFuelLiters:
                    float userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
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
            infoBuilder.AppendLine(Engine.ToString());

            return infoBuilder.ToString();
        }
    }
}
