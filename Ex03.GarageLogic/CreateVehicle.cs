using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        public enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        public static List<Tire> createListOfTires(Vehicle.eTireAmount i_TypeOfVehicle, string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            List<Tire> listOfTires = new List<Tire>();
            for (int i = 0; i < (int)i_TypeOfVehicle; i++)
            {
                Tire tire = new Tire(i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure);
                listOfTires.Add(tire);   
            }

            return listOfTires;
        }

        public static Car createCar(Car.eColor i_Color, Car.eNumberOfDoors i_NumberOfDoors)
        {
            Car newCar = new Car(i_Color, i_NumberOfDoors);

            return newCar;
        } 

        public static Motorcycle createMotorcycle(Motorcycle.eTypeOfLicense i_TypeOfLicense, int i_EngineCapacity)
        {
            Motorcycle newMotorcycle = new Motorcycle(i_TypeOfLicense, i_EngineCapacity);

            return newMotorcycle;
        }

        public static Truck createTruck(bool i_CarrierDangerousMaterials, float i_MaximumCarryingWeight)
        {
            Truck newTruck = new Truck(i_CarrierDangerousMaterials, i_MaximumCarryingWeight);

            return newTruck;
        }

        public static ElectricCar createElectricCar(Car i_Car, float i_RemainingBatteryTime, float i_MaxBatteryTime, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            ElectricCar newElectricCar = new ElectricCar(i_Car, i_RemainingBatteryTime, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires);

            return newElectricCar;
        }

        public static ElectricMotorcycle createElectricMotorcycle(Motorcycle i_Motorcycle, float i_RemainingBatteryTime, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            ElectricMotorcycle newElectricMotorcycle = new ElectricMotorcycle(i_Motorcycle, i_RemainingBatteryTime, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires);

            return newElectricMotorcycle;
        }

        public static FuelCar createFuelCar(Car i_Car, FuelVehicle.eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            FuelCar newFuelCar = new FuelCar(i_Car, i_FuelType, i_CurrentAmountOfFuel, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires);

            return newFuelCar;
        }

        public static FuelMotorcycle createFuelMotorcycle(Motorcycle i_Motorcycle, FuelVehicle.eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            FuelMotorcycle newFuelMotorcycle = new FuelMotorcycle(i_Motorcycle, i_FuelType, i_CurrentAmountOfFuel, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires);

            return newFuelMotorcycle;
        }

        public static FuelTruck createFuelTruck(Truck i_Truck, FuelVehicle.eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            FuelTruck newFuelTruck = new FuelTruck(i_Truck, i_FuelType, i_CurrentAmountOfFuel, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires);

            return newFuelTruck;
        }

        public static Client createClient(string i_OwnerName, string i_PhoneNumberOfOwner, Client.eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            Client newClient = new Client(i_OwnerName, i_PhoneNumberOfOwner, i_VehicleStatus, i_Vehicle);
            return newClient;
        }
    }
}
