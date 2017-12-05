using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInput
    {
        private static readonly string MAIN_OPTIONS =
@"Choose option:
1 - Add vehicle to garage
2 - Change the status of a vehicle
3 - Fill the tires of a vehicle
4 - Refueling vehicle (only fuel vehicle)
5 - Charge electric vehicle
6 - Get report of one vehicle in the garage
7 - Show all vehicles by license plate
8 - Exit";

        private static readonly string TYPE_OF_VEHICLE =
@"Vehicle type:
1 - Fuel motorcycle
2 - Electric motorcycle
3 - Fuel car 
4 - Electric car
5 - Truck";

        private static readonly string STATUS =
@"New status:
1 - Repairing
2 - Repaired
3 - Payed";

        private static readonly string FUEL_TYPE =
@"Gas type:
1 - Soler
2 - Octan95
3 - Octan96
4 - Octan98";

        private static readonly string MOTORCYCLE_LICENSE_TYPE =
@"License type:
1 - A
2 - A2
3 - AB
4 - B1";

        private static readonly string CONTAINS_HAZARDOUS_MATERIALS =
@"Contain hazardous materials:
1 - Yes
2 - No";

        private static readonly string DOORS_AMOUNT =
@"Doors amount:
1 - 2 doors
2 - 3 doors
3 - 4 doors
4 - 5 doors";

        private static readonly string CAR_COLOR =
@"Car color:
1 - Green
2 - Black
3 - White
4 - Red";

        private static readonly string SORT_BY_STATUS =
@"Sort by status:
1 - Repairing
2 - Repaired
3 - Payed
4 - None";

        public float getValidFloat(string i_Message, float i_MinVal, float i_MaxVal)
        {
            System.Console.WriteLine(i_Message);

            while (true)
            {
                string input = System.Console.ReadLine();
                float chosenNumber;
                bool validNumber = float.TryParse(input, out chosenNumber);

                validNumber = validNumber && ((chosenNumber >= i_MinVal) && (chosenNumber <= i_MaxVal));
                if (validNumber)
                {
                    return chosenNumber;
                }
                else
                {
                    System.Console.WriteLine(string.Format("Please enter a valid integer number from {0} to {1}", i_MinVal, i_MaxVal));
                }
            }
        }

        public int getValidInt(string i_Message, int i_MinVal, int i_MaxVal)
        {
            System.Console.WriteLine(i_Message);

            while (true)
            {
                string input = System.Console.ReadLine();
                int chosenNumber;
                bool validNumber = int.TryParse(input, out chosenNumber);

                validNumber = validNumber && ((chosenNumber >= i_MinVal) && (chosenNumber <= i_MaxVal));
                if (validNumber)
                {
                    return chosenNumber;
                }
                else
                {
                    System.Console.WriteLine(string.Format("Please enter a valid integer number from {0} to {1}", i_MinVal, i_MaxVal));
                }
            }
        }

        public string getValidString(string i_Message)
        {
            System.Console.WriteLine(i_Message);

            while (true)
            {
                string input = System.Console.ReadLine();

                if (!input.Equals(string.Empty))
                {
                    return input;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid string:");
                }
            }
        }

        public int getOption()
        {
            int option = getValidInt(MAIN_OPTIONS, 1, 8);
            return option;
        }

        public Client.eVehicleStatus getStatus()
        {
            Client.eVehicleStatus status = (Client.eVehicleStatus)getValidInt(STATUS, 1, 3);

            return status;
        }

        public string getLicensePlate()
        {
            string licensePlate = getValidString("Please enter a license plate:");
            return licensePlate;
        }

        public void changeStatusMessage()
        {
            System.Console.WriteLine("The status changed");
        }

        public void fillMaxAirMessage()
        {
            System.Console.WriteLine("Filling max air is completed");
        }

        public void suceededToChargeMessage()
        {
            System.Console.WriteLine("Suceeded to charge");
        }

        public void suceededToFillFuel()
        {
            System.Console.WriteLine("Suceeded to fill fuel");
        }

        public void suceededToAddMessage()
        {
            System.Console.WriteLine("Suceeded to add new vehicle");
        }

        public FuelVehicle.eFuelType getFuelType()
        {
            FuelVehicle.eFuelType fuelType = (FuelVehicle.eFuelType)getValidInt(FUEL_TYPE, 1, 4);

            return fuelType;
        }

        public float getAmountToRefuel()
        {
            float amountToRefuel = getValidFloat("Enter amount to refuel:", 0, float.MaxValue);
            return amountToRefuel;
        }

        public float getAmountToCharge()
        {
            float amountToCharge = getValidFloat("Enter amount to charge in minutes:", 0, float.MaxValue);
            return amountToCharge;
        }

        public void vehicleAlreadyInGarageMessage()
        {
            System.Console.WriteLine("This vehicle already in the garage and the status change to repairing");
        }

        public Client.eVehicleStatus howToSort()
        {
            int sort = getValidInt(SORT_BY_STATUS, 1, 4);

            return (Client.eVehicleStatus)sort;
        }

        public int getVehicleType()
        {
            int vehicleType = getValidInt(TYPE_OF_VEHICLE, 1, 5);
            return vehicleType;
        }

        public float getTiresPressure(float i_maxAirPressure)
        {
            float currentTirePressure = getValidFloat(string.Format("Please enter current tire pressure between {0} - {1}", 0, i_maxAirPressure), 0, i_maxAirPressure);
            return currentTirePressure;
        }

        public string getOwnerPhone()
        {
            while (true)
            {
                string phone = getValidString("Please enter your phone: (only digits)");
                if (isDigitsOnly(phone))
                {
                    return phone;
                }
            }
        }

        public Car.eNumberOfDoors getNumberOfDoors()
        {
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)getValidInt(DOORS_AMOUNT, 1, 4);
            return numberOfDoors;
        }

        public Car.eColor getCarColor()
        {
            Car.eColor carColor = (Car.eColor)getValidInt(CAR_COLOR, 1, 4);
            return carColor;
        }

        public Motorcycle.eTypeOfLicense getTypeOfLicense()
        {
            Motorcycle.eTypeOfLicense typeOfLicense = (Motorcycle.eTypeOfLicense)getValidInt(MOTORCYCLE_LICENSE_TYPE, 1, 4);
            return typeOfLicense;
        }

        public bool getIfCarrierDangerousMaterials()
        {
            bool isCarrier = false;
            int answer = getValidInt(CONTAINS_HAZARDOUS_MATERIALS, 1, 2);
            if (answer == 1)
            {
                isCarrier = true;
            }

            return isCarrier;
        }

        public float getCurrentAmountOfFuel(float i_MaxAmountOfFuel)
        {
            float currentAmountOfFuel = getValidFloat("Please enter current amount of fuel:", 0, i_MaxAmountOfFuel);
            return currentAmountOfFuel;
        }

        public float getRemainingBatteryTime(float i_MaxBatteryTime)
        {
            float remainingBatteryTime = getValidFloat("Please enter remaining battery time:", 0, i_MaxBatteryTime);
            return remainingBatteryTime;
        }

        private bool isDigitsOnly(string str)
        {
            bool isDigitOnly = true;
            foreach (char c in str)
            {
                if (c > '9' || c < '0')
                {
                   isDigitOnly  = false;
                }
            }

            return isDigitOnly;
        }
    }
}
