using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<Vehicle> VehiclesList { get; set; }

        public Garage()
        {
            VehiclesList = new List<Vehicle>();
        }

        public static float ConvertStrToNumber(string i_DataMemberStr, string i_ValueStr)
        {
            if (float.TryParse(i_ValueStr, out float valueNumber) == false)
            {
                throw new FormatException(string.Format($"{i_DataMemberStr} need to be only Numbers!"));
            }

            return valueNumber;
        }

        public static bool IsInputInRange(float i_Choice, float i_MinValue, float i_MaxValue)
        {
            if (i_Choice < i_MinValue || i_Choice > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }

            return true;
        }

        public static void BuildEnumOptions(StringBuilder i_Str, Type i_Enum)
        {
            string[] enumNames = Enum.GetNames(i_Enum);
            int index = 1;

            foreach (string enumName in enumNames)
            {
                i_Str.AppendLine(string.Format($"{index}) {enumName}"));
                index++;
            }
        }

        public void ChangeStatus(Vehicle i_VehicleToChange, Client.eStatus i_StatusToChange)
        {
            if (i_StatusToChange == i_VehicleToChange.ClientVehicle.VehicleStatus)
            {
                throw new ArgumentException($"The status {i_StatusToChange} is the current status");
            }

            if (IsInputInRange((float)i_StatusToChange, 1, Enum.GetNames(typeof(Client.eStatus)).Length))
            {
                i_VehicleToChange.ClientVehicle.VehicleStatus = i_StatusToChange;
            }
        }

        public StringBuilder ShowLicensePlateByStatus(Client.eStatus i_StatusToShow)
        {
            StringBuilder licensePlateMsg = new StringBuilder($"All {i_StatusToShow} Vehicles License Plate are: {System.Environment.NewLine}");

            if (IsInputInRange((float)i_StatusToShow, 1, Enum.GetNames(typeof(Client.eStatus)).Length))
            {
                foreach(Vehicle vehicleToShow in VehiclesList)
                {
                    if(vehicleToShow.ClientVehicle.VehicleStatus == i_StatusToShow)
                    {
                        licensePlateMsg.AppendLine(vehicleToShow.LicensePlate);
                    }
                }
            }

            return licensePlateMsg;
        }

        public bool IsLicensePlateInGarage(string i_LicensePlate)
        {
            bool isInGarage = false;

            foreach(Vehicle vehicle in VehiclesList)
            {
                if(vehicle.LicensePlate == i_LicensePlate)
                {
                    isInGarage = true;
                }
            }

            return isInGarage;
        }

        public Vehicle GetVehicleByLicensePlate(string i_LicensePlate)
        {
            Vehicle vehicleToLookFor = null;

            foreach (Vehicle vehicle in VehiclesList)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicleToLookFor = vehicle;
                    break;
                }
            }

            if(vehicleToLookFor == null)
            {
                throw new Exception($"there is no Vehicle with {i_LicensePlate} License Plate in Garage");
            }

            return vehicleToLookFor;
        }
    }
}
