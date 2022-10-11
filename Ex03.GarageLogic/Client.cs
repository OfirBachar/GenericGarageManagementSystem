using System;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_ClientName;
        private readonly string r_PhoneNumber;

        public string ClientName => r_ClientName;

        public string PhoneNumber => r_PhoneNumber;

        public eStatus VehicleStatus { get; set; }

        public enum eStatus
        {
            InRepair = 1,
            Fixed,
            Payed
        }

        public Client(string i_ClientName, string i_PhoneNumber)
        {
            r_ClientName = i_ClientName;
            r_PhoneNumber = i_PhoneNumber;
            VehicleStatus = eStatus.InRepair;
        }
    }
}
