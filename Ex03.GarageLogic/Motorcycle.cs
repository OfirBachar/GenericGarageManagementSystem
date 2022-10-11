using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        private const string k_LicenseTypeStr = "License Type";
        private const string k_EngineCapacityStr = "Engine Capacity";
        public const int k_NumberOfWheels = 2;
        public const float k_MaxAirPressureWheel = 31;

        private eLicenseType m_LicenseType;
        public eLicenseType LicenseType
        {
            get => m_LicenseType;
            set
            {
                int sizeOfLicenseTypes = Enum.GetNames(typeof(eLicenseType)).Length;

                if (Garage.IsInputInRange((float)value, 1, sizeOfLicenseTypes))
                {
                    m_LicenseType = value;
                }
            }
        }

        public int EngineCapacity { get; set; }

        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            BB,
        }

        protected Motorcycle(float i_MaxAirPressure, int i_NumOfWheels) : base(i_MaxAirPressure, i_NumOfWheels)
        {
            insertDataInfo();
        }

        private void insertDataInfo()
        {
            StringBuilder licenseTypeStr = new StringBuilder();
            Garage.BuildEnumOptions(licenseTypeStr, typeof(eLicenseType));
            DataInfo.Add(k_LicenseTypeStr, licenseTypeStr.ToString());
            DataInfo.Add(k_EngineCapacityStr, null);
        }

        public override void InsertInput(string i_DataMember, string i_Value)
        {
            float userChoiceNumber;

            switch (i_DataMember)
            {
                case k_LicenseTypeStr:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    LicenseType = (eLicenseType)userChoiceNumber;
                    break;
                case k_EngineCapacityStr:
                    userChoiceNumber = Garage.ConvertStrToNumber(i_DataMember, i_Value);
                    EngineCapacity = (int)userChoiceNumber;
                    break;
                default:
                    base.InsertInput(i_DataMember, i_Value);
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder(base.ToString());
            infoBuilder.AppendLine($"The License Type is: {LicenseType}");
            infoBuilder.AppendLine($"The Engine Capacity is: {EngineCapacity}");

            return infoBuilder.ToString();
        }
    }
}