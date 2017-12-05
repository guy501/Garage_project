using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;
        public const float k_MaxBatteryTime = 1.9f;

        public ElectricMotorcycle(Motorcycle i_Motorcycle, float i_RemainingBatteryTime, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
            : base(i_RemainingBatteryTime, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires, k_MaxBatteryTime)
        {
            m_Properties.Add(new Property("Max battery time", typeof(float)), k_MaxBatteryTime);
            m_Motorcycle = i_Motorcycle;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Max battery time: {2} {1} {3}", base.ToString(), System.Environment.NewLine, k_MaxBatteryTime, m_Motorcycle.ToString());
        }
    }
}
