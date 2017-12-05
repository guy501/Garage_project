using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private GarageLogic.Garage m_Garage = new GarageLogic.Garage();
        private UserInput m_UserInputs = new UserInput();

        public void Run()
        {
            int option = 0;

            while (true)
            {
                option = m_UserInputs.getOption();

                switch (option)
                {
                    case 1:

                        addNewVehicleToGarage();
                        break;

                    case 2:

                        changeStatus();
                        break;

                    case 3:

                        fillMaxAirInTires();
                        break;

                    case 4:

                        fillFuel();
                        break;

                    case 5:

                        chargeElectricVehicle();
                        break;

                    case 6:

                        showFullVehicleDetails();
                        break;

                    case 7:

                        showAllVehiclesInGarageByLicense();
                        break;

                    case 8:

                        System.Threading.Thread.Sleep(2000);
                        return;
                }

                System.Console.Clear();
            }
        }

        public void showFullVehicleDetails()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            try
            {
                m_Garage.vehicleAlreadyInGarage(licensePlate);
                Client client = m_Garage.m_AllVehiclesInTheGarage[licensePlate];
                List<string> allDetails = m_Garage.fullDetailsOfVehicle(client);
                foreach (string detail in allDetails)
                {
                    System.Console.WriteLine(detail);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
            System.Console.ReadLine();
        }

        public void changeStatus()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            Client.eVehicleStatus newStatus = m_UserInputs.getStatus();
            try
            {
                m_Garage.changeVehicleStatus(licensePlate, newStatus);
                m_UserInputs.changeStatusMessage();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }

        public void fillMaxAirInTires()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            try
            {
                m_Garage.vehicleAlreadyInGarage(licensePlate);
                m_Garage.fillingAirToMax(licensePlate);
                m_UserInputs.fillMaxAirMessage();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }

        public void fillFuel()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            FuelVehicle.eFuelType fuelType = m_UserInputs.getFuelType();
            float amountToRefuel = m_UserInputs.getAmountToRefuel();
            try
            {
                m_Garage.refuelingFuelVehicle(licensePlate, fuelType, amountToRefuel);
                m_UserInputs.suceededToFillFuel();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }

        public void chargeElectricVehicle()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            float amountToCharge = m_UserInputs.getAmountToCharge();

            try
            {
                m_Garage.chargeElectricVehicle(licensePlate, amountToCharge);
                m_UserInputs.suceededToChargeMessage();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }

        public void showAllVehiclesInGarageByLicense()
        {
            Client.eVehicleStatus sortBy = m_UserInputs.howToSort();
            List<string> vehicles = m_Garage.listOfVehiclesInGarage(sortBy);
            foreach (string vehicle in vehicles)
            {
                System.Console.WriteLine(vehicle);
            }

            System.Console.ReadLine();
        }

        private void addNewVehicleToGarage()
        {
            string licensePlate = m_UserInputs.getLicensePlate();
            float maxAirPressure = 0;
            float maxBatteryTime = 0;
            FuelVehicle.eFuelType fuelType;
            Vehicle.eTireAmount tireAmount;

            if (m_Garage.m_AllVehiclesInTheGarage.ContainsKey(licensePlate))
            {
                m_Garage.changeVehicleStatus(licensePlate, Client.eVehicleStatus.Repairing);
                m_UserInputs.vehicleAlreadyInGarageMessage();
            }
            else
            {
                string vehicleModel = m_UserInputs.getValidString("Please enter vehicle model name:");
                string ownerName = m_UserInputs.getValidString("Please enter Owner Name");
                string ownerPhone = m_UserInputs.getOwnerPhone();
                float percentOfRemainingEnergy = 0;
                Client newClient = null;

                CreateVehicle.eVehicleType vehicleType = (CreateVehicle.eVehicleType)m_UserInputs.getVehicleType();

                string tiresManufacturer = m_UserInputs.getValidString("Please enter the tires manufacturer:");
                float currentTireAirPressure;
                List<Tire> listOfTires;
                Vehicle vehicleForProperty;

                if (vehicleType == CreateVehicle.eVehicleType.ElectricCar || vehicleType == CreateVehicle.eVehicleType.FuelCar)
                {
                    maxAirPressure = (float)Tire.eMaxAirPressure.Car;
                    currentTireAirPressure = m_UserInputs.getTiresPressure(maxAirPressure);
                    tireAmount = Vehicle.eTireAmount.Car;
                    listOfTires = CreateVehicle.createListOfTires(tireAmount, tiresManufacturer, currentTireAirPressure, maxAirPressure);
                    Car.eColor carColor = m_UserInputs.getCarColor();
                    Car.eNumberOfDoors numberOfDoors = m_UserInputs.getNumberOfDoors();
                    Car car = CreateVehicle.createCar(carColor, numberOfDoors);

                    if (vehicleType == CreateVehicle.eVehicleType.ElectricCar)
                    {
                        float remainingBatteryTime = m_UserInputs.getRemainingBatteryTime(ElectricCar.k_MaxBatteryTime);
                        percentOfRemainingEnergy = Vehicle.getPercentOfEnergy(remainingBatteryTime, ElectricCar.k_MaxBatteryTime);
                        ElectricCar electricCar = CreateVehicle.createElectricCar(car, remainingBatteryTime, maxBatteryTime, vehicleModel, licensePlate, percentOfRemainingEnergy, listOfTires);
                        newClient = CreateVehicle.createClient(ownerName, ownerPhone, Client.eVehicleStatus.Repairing, electricCar);
                    }
                    else
                    {
                        fuelType = FuelVehicle.eFuelType.Octan98;
                        float currentAmountOfFuel = m_UserInputs.getCurrentAmountOfFuel(FuelCar.k_MaxAmountOfFuel);
                        percentOfRemainingEnergy = Vehicle.getPercentOfEnergy(currentAmountOfFuel, FuelCar.k_MaxAmountOfFuel);
                        FuelCar fuelCar = CreateVehicle.createFuelCar(car, fuelType, currentAmountOfFuel, vehicleModel, licensePlate, percentOfRemainingEnergy, listOfTires);
                        newClient = CreateVehicle.createClient(ownerName, ownerPhone, Client.eVehicleStatus.Repairing, fuelCar);
                    }

                    vehicleForProperty = newClient.m_Vehicle;
                    Car.setProperties(vehicleForProperty, carColor, numberOfDoors);
                }
                else if (vehicleType == CreateVehicle.eVehicleType.ElectricMotorcycle || vehicleType == CreateVehicle.eVehicleType.FuelMotorcycle)
                {
                    maxAirPressure = (float)Tire.eMaxAirPressure.Motorcycle;
                    currentTireAirPressure = m_UserInputs.getTiresPressure(maxAirPressure);
                    tireAmount = Vehicle.eTireAmount.Motorcycle;
                    listOfTires = CreateVehicle.createListOfTires(tireAmount, tiresManufacturer, currentTireAirPressure, maxAirPressure);
                    Motorcycle.eTypeOfLicense typeOfLicense = m_UserInputs.getTypeOfLicense();
                    int engineCapacity = m_UserInputs.getValidInt("Please enter engine capacity:", 0, int.MaxValue);
                    Motorcycle motorCycle = CreateVehicle.createMotorcycle(typeOfLicense, engineCapacity);

                    if (vehicleType == CreateVehicle.eVehicleType.ElectricMotorcycle)
                    {
                        float remainingBatteryTime = m_UserInputs.getRemainingBatteryTime(ElectricMotorcycle.k_MaxBatteryTime);
                        percentOfRemainingEnergy = Vehicle.getPercentOfEnergy(remainingBatteryTime, ElectricMotorcycle.k_MaxBatteryTime);
                        ElectricMotorcycle electricMotorcycle = CreateVehicle.createElectricMotorcycle(motorCycle, remainingBatteryTime, vehicleModel, licensePlate, percentOfRemainingEnergy, listOfTires);
                        newClient = CreateVehicle.createClient(ownerName, ownerPhone, Client.eVehicleStatus.Repairing, electricMotorcycle);
                    }
                    else
                    {
                        fuelType = FuelVehicle.eFuelType.Octan95;
                        float currentAmountOfFuel = m_UserInputs.getCurrentAmountOfFuel(FuelMotorcycle.k_MaxAmountOfFuel);
                        percentOfRemainingEnergy = Vehicle.getPercentOfEnergy(currentAmountOfFuel, FuelMotorcycle.k_MaxAmountOfFuel);
                        FuelMotorcycle fuelMotorcycle = CreateVehicle.createFuelMotorcycle(motorCycle, fuelType, currentAmountOfFuel, vehicleModel, licensePlate, percentOfRemainingEnergy, listOfTires);
                        newClient = CreateVehicle.createClient(ownerName, ownerPhone, Client.eVehicleStatus.Repairing, fuelMotorcycle);
                    }

                    vehicleForProperty = newClient.m_Vehicle;
                    Motorcycle.setProperties(vehicleForProperty, typeOfLicense, engineCapacity);
                }
                else if (vehicleType == CreateVehicle.eVehicleType.Truck)
                {
                    maxAirPressure = (float)Tire.eMaxAirPressure.Truck;
                    currentTireAirPressure = m_UserInputs.getTiresPressure(maxAirPressure);
                    tireAmount = Vehicle.eTireAmount.Truck;
                    listOfTires = CreateVehicle.createListOfTires(tireAmount, tiresManufacturer, currentTireAirPressure, maxAirPressure);
                    fuelType = FuelVehicle.eFuelType.Soler;
                    bool carrierDangerousMaterials = m_UserInputs.getIfCarrierDangerousMaterials();
                    float maximumCarryingWeight = m_UserInputs.getValidFloat("Please enter maximum carry weight:", 0, int.MaxValue);
                    Truck truck = CreateVehicle.createTruck(carrierDangerousMaterials, maximumCarryingWeight);
                    float currentAmountOfFuel = m_UserInputs.getCurrentAmountOfFuel(FuelTruck.k_MaxAmountOfFuel);
                    percentOfRemainingEnergy = Vehicle.getPercentOfEnergy(currentAmountOfFuel, FuelTruck.k_MaxAmountOfFuel);
                    FuelTruck fuelTruck = CreateVehicle.createFuelTruck(truck, fuelType, currentAmountOfFuel, vehicleModel, licensePlate, percentOfRemainingEnergy, listOfTires);
                    newClient = CreateVehicle.createClient(ownerName, ownerPhone, Client.eVehicleStatus.Repairing, fuelTruck);
                    vehicleForProperty = newClient.m_Vehicle;
                    Truck.setProperties(vehicleForProperty, carrierDangerousMaterials, maximumCarryingWeight);
                }

                m_Garage.addVehicle(newClient);
                m_UserInputs.suceededToAddMessage();
            }

            System.Console.ReadLine();
        }
    }
}
