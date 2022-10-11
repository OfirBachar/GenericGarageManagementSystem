using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class CarData
    {
        public const string k_CarColorStr = "Car Color";
        public const string k_DoorsNumber = "Doors Number";

        public eCarColor CarColor { get; set; }

        public int DoorsNumber { get; set; }

        public enum eCarColor
        {
            Red = 1,
            White,
            Green,
            Blue,
        }

        public bool InsertCarDataInput(string i_DataMember, string i_Value)
        {
            float userChoiceNumber;
            bool isDefault = false;
            switch (i_DataMember)
            {
                case k_CarColorStr:
                    userChoiceNumber = Vehicle.ConvertStrToNumber(i_DataMember, i_Value);
                    int sizeOfColors = Enum.GetNames(typeof(eCarColor)).Length;
                    if (Vehicle.IsInputInRange(userChoiceNumber, 1, sizeOfColors))
                    {
                        CarColor = (eCarColor)userChoiceNumber;
                    }

                    break;
                case k_DoorsNumber:
                    userChoiceNumber = Vehicle.ConvertStrToNumber(i_DataMember, i_Value);
                    if (Vehicle.IsInputInRange(userChoiceNumber, 2, 5))
                    {
                        DoorsNumber = (int)userChoiceNumber;
                    }

                    break;
                default:
                    isDefault = true;
                    break;
            }

            return isDefault;
        }
    }
}
