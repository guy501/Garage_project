using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private Car m_Car;
        public const float k_MaxBatteryTime = 3.3f;

        public ElectricCar(Car i_Car, float i_RemainingBatteryTime, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires) 
            : base(i_RemainingBatteryTime, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires, k_MaxBatteryTime)
        {
            m_Properties.Add(new Property("Max battery time", typeof(float)), k_MaxBatteryTime);
            m_Car = i_Car;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Max battery time: {2} {1} {3}", base.ToString(), System.Environment.NewLine, k_MaxBatteryTime, m_Car.ToString());
        }
    }
}
