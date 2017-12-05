using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
        }

        public FuelVehicle(eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires, float i_MaxAmountOfFuel)
            : base(i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires)
        {
            this.m_FuelType = i_FuelType;
            this.m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            this.m_MaxAmountOfFuel = i_MaxAmountOfFuel;
            m_Properties.Add(new Property("Fuel type", typeof(eFuelType)), i_FuelType);
            m_Properties.Add(new Property("Current amount of fuel", typeof(float)), i_CurrentAmountOfFuel);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Fuel type: {2} {1}Current amount of fuel: {3}", base.ToString(), System.Environment.NewLine, m_FuelType, m_CurrentAmountOfFuel);
        }

        public bool refueling(eFuelType i_FuelType, float i_AmountToRefuel)
        {
            bool theRefuelSucceeded = false;

            if(i_FuelType != m_FuelType)
            {
                throw new ArgumentException("This fuel type isn't correct");
            }
            
            if ((m_CurrentAmountOfFuel + i_AmountToRefuel) <= m_MaxAmountOfFuel)
            {
                theRefuelSucceeded = true;
                m_CurrentAmountOfFuel += i_AmountToRefuel;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfFuel - m_CurrentAmountOfFuel);
            }

            return theRefuelSucceeded;
        }
    }
}
