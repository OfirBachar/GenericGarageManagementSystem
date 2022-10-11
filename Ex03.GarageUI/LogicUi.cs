using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageUI
{
    internal class LogicUi
    {
        private readonly Garage r_Garage;

        public LogicUi()
        {
            r_Garage = new Garage();
        }

        public void StartMenu()
        {
            int userChoiceNumber = 0;

            while (userChoiceNumber != 8)
            {
                PrintMenu();
                string userChoice = Console.ReadLine();

                try
                {
                    userChoiceNumber = getUserChoice(userChoice);
                    makeUserChoice(userChoiceNumber);
                }
                catch(Exception exception)
                {
                    Console.Clear();
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void PrintMenu()
        {
            string menu = string.Format(
                @"
Hello! Welcome To Our Garage!

Please Select from the following:
1. Enter new Vehicle
2. Show all license plate
3. Change status of vehicle in garage
4. Inflate wheels of a vehicle
5. Gas a fuel vehicle
6. Charge an electric vehicle
7. show full Info of a vehicle
8. Exit");

            Console.WriteLine(menu);
        }

        private void makeUserChoice(int i_UserChoice)
        {
            Console.Clear();

            switch (i_UserChoice)
            {
                case 1:
                    getNewVehicle();
                    break;
                case 2:
                    showAllLicensePlate();
                    break;
                case 3:
                    changeStatusOfVehicle();
                    break;
                case 4:
                    addAirPressureToMax();
                    break;
                case 5:
                    addFuelToFuelEngine();
                    break;
                case 6:
                    chargeElectricToBattery();
                    break;
                case 7:
                    printSpecificVehicle();
                    break;
                case 8:
                    break;
                default:
                    throw new ValueOutOfRangeException(1, 8);
            }
        }

        private void getNewVehicle()
        {
            string licensePlate = getLicensePlateFromUser();

            if(r_Garage.IsLicensePlateInGarage(licensePlate) == true)
            {
                Vehicle vehicle = r_Garage.GetVehicleByLicensePlate(licensePlate);
                Console.WriteLine("Vehicle is already in garage");
                vehicle.ClientVehicle.VehicleStatus = Client.eStatus.InRepair;
            }
            else
            {
                Client client = getClientData();
                VehicleCreator.eVehicleType vehicleType = whichVehicleTypeToAdd();
                Vehicle vehicleToCreate = VehicleCreator.MakeNewVehicle(vehicleType);
                vehicleToCreate.ClientVehicle = client;
                GetDataForSpecificVehicle(vehicleToCreate, licensePlate);
                r_Garage.VehiclesList.Add(vehicleToCreate);
            }
        }

        private int getUserChoice(string i_UserChoice)
        {
            int userChoiceNumber;
            bool parsingSucceed = int.TryParse(i_UserChoice, out userChoiceNumber);

            if (parsingSucceed == false)
            {
                throw new FormatException($"InValid Input - Should be made only by numbers.{System.Environment.NewLine}");
            }

            return userChoiceNumber;
        }

        private void addAirPressureToMax()
        {
            string licensePlate = getLicensePlateFromUser();
            Vehicle vehicleToAddPressure = r_Garage.GetVehicleByLicensePlate(licensePlate);
            vehicleToAddPressure.AddPressureToMax();
            Console.WriteLine("Inflation wheels of the vehicle succeed");
        }

        private void addFuelToFuelEngine()
        {
            string licensePlate = getLicensePlateFromUser();
            Vehicle vehicleToAddFuel = r_Garage.GetVehicleByLicensePlate(licensePlate);
            Engine engine = vehicleToAddFuel.Engine;

            if(engine is FuelEngine)
            {
                printWhichFuelType();
                string fuelTypeChoice = Console.ReadLine();
                FuelEngine.eFuelTypes fuelType = (FuelEngine.eFuelTypes)getUserChoice(fuelTypeChoice);
                Console.WriteLine($"Insert Amount Fuel to add: (number between  0 and {engine.MaxPower - engine.RemainingPower})");
                string fuelAmountToAdd = Console.ReadLine();
                float fuelAmountNumber = getUserChoiceFloat(fuelAmountToAdd);
                engine.AddPowerToEngine(fuelAmountNumber, fuelType);
            }
            else
            {
                throw new FormatException("Your Vehicle is not Fuel Vehicle");
            }
        }

        private float getUserChoiceFloat(string i_UserChoice)
        {
            float userChoiceNumber;
            bool parsingSucceed = float.TryParse(i_UserChoice, out userChoiceNumber);

            if (parsingSucceed == false)
            {
                throw new FormatException($"InValid Input - Should be made only by numbers.{System.Environment.NewLine}");
            }

            return userChoiceNumber;
        }

        private void printWhichFuelType()
        {
            Console.Clear();
            StringBuilder fuelTypesMsg = new StringBuilder($"Insert which Fuel type to add:{System.Environment.NewLine}");
            Garage.BuildEnumOptions(fuelTypesMsg, typeof(FuelEngine.eFuelTypes));
            Console.WriteLine(fuelTypesMsg);
        }

        private void chargeElectricToBattery()
        {
            string licensePlate = getLicensePlateFromUser();
            Vehicle vehicleToAddFuel = r_Garage.GetVehicleByLicensePlate(licensePlate);
            Engine engine = vehicleToAddFuel.Engine;

            if (engine is ElectricEngine electricEngine)
            {
                Console.WriteLine($"Insert Amount Time in Minutes to Charge: (number between  0 and {(electricEngine.MaxPower - electricEngine.RemainingPower) * 60})");
                string MinutesAmountToAdd = Console.ReadLine();
                float MinutesAmountNumber = getUserChoiceFloat(MinutesAmountToAdd);
                electricEngine.AddPowerToEngine(MinutesAmountNumber / 60);
            }
            else
            {
                throw new FormatException("Your Vehicle is not Electric Vehicle");
            }
        }

        private void changeStatusOfVehicle()
        {
            Console.WriteLine("Please enter license plate for the required Vehicle:");
            string licensePlateToChange = Console.ReadLine();
            Vehicle vehicleToChange = r_Garage.GetVehicleByLicensePlate(licensePlateToChange);
            StringBuilder reqStatusMsg = new StringBuilder($"Please enter new status for the required Vehicle:{ System.Environment.NewLine}");
            Garage.BuildEnumOptions(reqStatusMsg, typeof(Client.eStatus));
            Console.WriteLine(reqStatusMsg);
            string reqStatusOfVehicle = Console.ReadLine();
            float reqStatusNum = getUserChoice(reqStatusOfVehicle);
            r_Garage.ChangeStatus(vehicleToChange, (Client.eStatus)reqStatusNum);
        }

        private void showAllLicensePlate()
        {
            StringBuilder reqStatusMsg = new StringBuilder($"Please select which Status of Vehicles you would like to see:{System.Environment.NewLine}");
            Garage.BuildEnumOptions(reqStatusMsg, typeof(Client.eStatus));
            Console.WriteLine(reqStatusMsg);
            string reqStatusOfVehicle = Console.ReadLine();
            float reqStatusNum = getUserChoice(reqStatusOfVehicle);
            StringBuilder licensePlateMsg = r_Garage.ShowLicensePlateByStatus((Client.eStatus)reqStatusNum);
            Console.WriteLine(licensePlateMsg);
        }

        private void printSpecificVehicle()
        {
            string licensePlateToPrint = getLicensePlateFromUser();
            Vehicle vehicleToPrint = r_Garage.GetVehicleByLicensePlate(licensePlateToPrint);
            Console.Clear();
            Console.WriteLine(vehicleToPrint.ToString());
            Console.WriteLine(System.Environment.NewLine);
        }

        private string getLicensePlateFromUser()
        {
            Console.Clear();
            Console.WriteLine("Please enter license plate for the required Vehicle:");
            string licensePlateToLookFor = Console.ReadLine();

            if(licensePlateToLookFor != null && licensePlateToLookFor.All(char.IsDigit) == false)
            {
                throw new FormatException("License Plate need to be only numbers!");
            }

            return licensePlateToLookFor;
        }

        private VehicleCreator.eVehicleType whichVehicleTypeToAdd()
        {
            Console.Clear();
            StringBuilder vehicleNames = new StringBuilder($"Please select which car type you want to Add: {System.Environment.NewLine}");
            Garage.BuildEnumOptions(vehicleNames, typeof(VehicleCreator.eVehicleType));
            Console.WriteLine(vehicleNames);
            string userChoice = Console.ReadLine();
            int userChoiceNumber = getUserChoice(userChoice);
            int numberOfTypes = Enum.GetNames(typeof(VehicleCreator.eVehicleType)).Length;
            Garage.IsInputInRange(userChoiceNumber, 1, numberOfTypes);

            return (VehicleCreator.eVehicleType)userChoiceNumber;
        }

        private Client getClientData()
        {
            Console.Clear();
            Console.WriteLine($"Please enter your Name:{System.Environment.NewLine}");
            string clientName = Console.ReadLine();
            Console.WriteLine($"Please enter your PhoneNumber:{System.Environment.NewLine}");
            string phoneNumber = Console.ReadLine();
            Client client = new Client(clientName, phoneNumber);

            return client;
        }

        private void GetDataForSpecificVehicle(Vehicle i_Vehicle, string i_LicensePlate)
        {
            foreach(KeyValuePair<string, string> keyValuePair in i_Vehicle.DataInfo)
            {
                Console.Clear();

                if (keyValuePair.Key == Vehicle.k_LicensePlateStr)
                {
                    i_Vehicle.InsertInput(keyValuePair.Key, i_LicensePlate);
                    continue;
                }
                
                Console.WriteLine($"Please Insert {keyValuePair.Key}");

                if(keyValuePair.Value != null)
                {
                    Console.WriteLine(keyValuePair.Value);
                }

                string userChoice = Console.ReadLine();
                i_Vehicle.InsertInput(keyValuePair.Key, userChoice);
            }
        }
    }
}
