using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public List<eVehicleType> VehiclesTypeList { get; set; }

        public VehicleCreator()
        {
            VehiclesTypeList = new List<eVehicleType>();

            foreach (eVehicleType vehicleType in Enum.GetValues(typeof(eVehicleType)))
            {
                VehiclesTypeList.Add(vehicleType);
            }
        }

        public enum eVehicleType
        {
            FuelCar = 1,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        public static Vehicle MakeNewVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicleToCreate = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    vehicleToCreate = new FuelCar(FuelCar.k_FuelType, FuelCar.k_MaxFuelLiters, Car.k_MaxAirPressureWheel, Car.k_NumberOfWheels);
                    break;

                case eVehicleType.ElectricCar:
                    vehicleToCreate = new ElectricCar(ElectricCar.k_MaxBatteryHours, Car.k_MaxAirPressureWheel, Car.k_NumberOfWheels);
                    break;

                case eVehicleType.FuelMotorcycle:
                    vehicleToCreate = new FuelMotorcycle(FuelMotorcycle.k_FuelType, FuelMotorcycle.k_MaxFuelLiters, FuelMotorcycle.k_MaxAirPressureWheel, FuelMotorcycle.k_NumberOfWheels);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicleToCreate = new ElectricMotorcycle(ElectricMotorcycle.k_MaxBatteryHours, ElectricMotorcycle.k_MaxAirPressureWheel, ElectricMotorcycle.k_NumberOfWheels);
                    break;

                case eVehicleType.Truck:
                    vehicleToCreate = new Truck(Truck.k_FuelType, Truck.k_MaxFuelLiters, Truck.k_MaxAirPressureWheel, Truck.k_NumberOfWheels);
                    break;
            }

            return vehicleToCreate;
        }
    }
}
