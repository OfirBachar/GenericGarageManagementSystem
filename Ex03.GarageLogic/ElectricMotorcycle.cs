using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public const float k_MaxBatteryHours = 2.5f;

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

        public ElectricMotorcycle(float i_MaxBatteryHours, float i_MaxAirPressure, int i_NumOfWheels) : base(i_MaxAirPressure, i_NumOfWheels)
        {
            m_Engine = new ElectricEngine(i_MaxBatteryHours);
            DataInfo.Add(ElectricEngine.k_RemainingBatteryHoursStr, string.Format($"insert number between 0 and {k_MaxBatteryHours - m_Engine.RemainingPower}"));
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            switch (i_DataMember)
            {
                case ElectricEngine.k_RemainingBatteryHoursStr:
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