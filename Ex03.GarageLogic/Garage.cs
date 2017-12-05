using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public Dictionary<string, Client> m_AllVehiclesInTheGarage;

        public Garage()
        {
            m_AllVehiclesInTheGarage = new Dictionary<string, Client>();
        }

        public void addVehicle(Client io_client)
        {
            string licensePlateNumber = io_client.m_Vehicle.m_LicensePlateNumber;
            m_AllVehiclesInTheGarage.Add(licensePlateNumber, io_client);
            io_client.m_VehicleStatus = Client.eVehicleStatus.Repairing;
        }

        public bool vehicleAlreadyInGarage(string i_LicensePlateNumber)
        {
            bool vehicleInTheGarage = false;
            if (m_AllVehiclesInTheGarage.ContainsKey(i_LicensePlateNumber))
            {
                vehicleInTheGarage = true;
            }
            else
            {
                throw new ArgumentException("This vehicle isn't in the garage");
            }

            return vehicleInTheGarage;
        }

        public bool changeVehicleStatus(string i_LicensePlate, Client.eVehicleStatus i_NewStatus)
        {
            bool inGarage = false;

            if (vehicleAlreadyInGarage(i_LicensePlate))
            {
                Client clientToChangeStatus = m_AllVehiclesInTheGarage[i_LicensePlate];
                clientToChangeStatus.m_VehicleStatus = i_NewStatus;
                inGarage = true;
            }

            return inGarage;
        }

        public List<string> listOfVehiclesInGarage(Client.eVehicleStatus i_SortBy)
        {
            List<string> listOfVehicles = new List<string>();

            foreach (KeyValuePair<string, Client> pair in m_AllVehiclesInTheGarage)
            {
                if (pair.Value.m_VehicleStatus.Equals(i_SortBy) || i_SortBy.Equals(Client.eVehicleStatus.none))
                {
                    listOfVehicles.Add(pair.Key);
                }
            }

            return listOfVehicles;
        }

        public bool fillingAirToMax(string i_LicensePlate)
        {
            bool fillingAirSucceeded = false;
            if (m_AllVehiclesInTheGarage.ContainsKey(i_LicensePlate))
            {
                Vehicle vehicleToFillAir = m_AllVehiclesInTheGarage[i_LicensePlate].m_Vehicle;
                List<Tire> VehicleTiresToFill = vehicleToFillAir.m_Tires;

                foreach (Tire tire in VehicleTiresToFill)
                {
                    float amountAirToFill = tire.m_MaxAirPressure - tire.m_CurrentAirPressure;
                    fillingAirSucceeded = tire.fillingAir(amountAirToFill);
                }
            }

            return fillingAirSucceeded;
        }

        public void refuelingFuelVehicle(string i_LicensePlate, FuelVehicle.eFuelType i_FuelType, float i_AmountToRefuel)
        {
            if (m_AllVehiclesInTheGarage.ContainsKey(i_LicensePlate))
            {
                Vehicle vehicleToFuel = m_AllVehiclesInTheGarage[i_LicensePlate].m_Vehicle;

                if (vehicleToFuel is FuelVehicle)
                {
                    ((FuelVehicle)vehicleToFuel).refueling(i_FuelType, i_AmountToRefuel);
                }
                else
                {
                    throw new ArgumentException("This vehicle isn't a fuel vehicle");
                }
            }
            else
            {
                throw new ArgumentException("This Vehicle isn't in the garage");
            }
        }

        public void chargeElectricVehicle(string i_LicensePlate, float i_minutesToCharge)
        {
            float hourToCharge = i_minutesToCharge / 60;

            if (m_AllVehiclesInTheGarage.ContainsKey(i_LicensePlate))
            {
                Vehicle vehicleToCharge = m_AllVehiclesInTheGarage[i_LicensePlate].m_Vehicle;
                if(vehicleToCharge is ElectricVehicle)
                {
                    ((ElectricVehicle)vehicleToCharge).ChargingBattery(hourToCharge);
                }
                else
                {
                    throw new ArgumentException("This vehicle isn't a electric vehicle");
                }
            }
            else
            {
                throw new ArgumentException("This Vehicle isn't in the garage");
            }
        }

        public List<string> fullDetailsOfVehicle(Client i_client)
        {
            Vehicle vehicle = i_client.m_Vehicle;
            List<string> GarageReport = new List<string>();
            GarageReport.Add(i_client.ToString());
            GarageReport.Add(i_client.m_Vehicle.ToString());
            GarageReport.Add("Tires manufacturer: " + vehicle.m_Tires[0].m_Manufacturer);
            GarageReport.Add(string.Format("Tires air pressure: {0} out of {1}", vehicle.m_Tires[0].m_CurrentAirPressure, vehicle.m_Tires[0].m_MaxAirPressure));

          return GarageReport;
        }
    }
}
