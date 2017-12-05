using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public ElectricVehicle(float i_RemainingBatteryTime, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires, float i_MaxBatteryTime)
            : base(i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires)
        {
            this.m_RemainingBatteryTime = i_RemainingBatteryTime;
            this.m_MaxBatteryTime = i_MaxBatteryTime;
            m_Properties.Add(new Property("Remaining battery time", typeof(float)), i_RemainingBatteryTime);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Remaining battery time : {2}", base.ToString(), System.Environment.NewLine, m_RemainingBatteryTime);
        }

        public bool ChargingBattery(float i_hourToCharge)
        {
            bool theChargingSucceeded = false;

            if(m_RemainingBatteryTime + i_hourToCharge <= m_MaxBatteryTime)
            {
                theChargingSucceeded = true;
                m_RemainingBatteryTime = m_RemainingBatteryTime + i_hourToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, (m_MaxBatteryTime - m_RemainingBatteryTime) * 60);
            }

            return theChargingSucceeded;
        }
    }
}
