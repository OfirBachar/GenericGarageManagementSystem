using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        private const string k_CarColorStr = "Car Color";
        private const string k_DoorsNumberStr = "Doors Number";
        public const int k_NumberOfWheels = 4;
        public const float k_MaxAirPressureWheel = 29;
        private const int k_MaxNumberOfDoors = 5;

        private eCarColor m_CarColor;

        private int m_DoorsNumber;

        public int DoorsNumber
        {
            get => m_DoorsNumber;
            private set
            {
                if (Garage.IsInputInRange(value, 2, k_MaxNumberOfDoors))
                {
                    m_DoorsNumber = value;
                }
            }
        }

        public eCarColor CarColor
        {
            get => m_CarColor;
            private set
            {
                int sizeOfColors = Enum.GetNames(typeof(eCarColor)).Length;
                if (Garage.IsInputInRange((float)value, 1, sizeOfColors))
                {
                     m_CarColor = value;
                }
            }
        }

        public enum eCarColor
        {
            Red = 1,
            White,
            Green,
            Blue,
        }

        protected Car(float i_MaxAirPressure, int i_NumOfWheels) : base(i_MaxAirPressure, i_NumOfWheels)
        {
            insertDataInfo();
        }

        private void insertDataInfo()
        {
            StringBuilder colorStr = new StringBuilder();
            Garage.BuildEnumOptions(colorStr, typeof(eCarColor));
            DataInfo.Add(k_CarColorStr, colorStr.ToString());
            DataInfo.Add(k_DoorsNumberStr, string.Format($"Insert number between 2 and {k_MaxNumberOfDoors}"));
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            float userChoiceNumber;

            switch (i_DataMember)
            {
                case k_CarColorStr:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    CarColor = (eCarColor)userChoiceNumber;
                    break;
                case k_DoorsNumberStr:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    DoorsNumber = (int)userChoiceNumber;
                    break;
                default:
                    base.InsertInput(i_DataMember, i_Value);
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder(base.ToString());
            infoBuilder.AppendLine($"The Color is: {CarColor}");
            infoBuilder.AppendLine($"The Amount of Doors is: {DoorsNumber}");

            return infoBuilder.ToString();
        }
    }
}
