using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private Car m_Car;
        public const float k_MaxAmountOfFuel = 38f;

        public FuelCar(Car i_Car, FuelVehicle.eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
            : base(i_FuelType, i_CurrentAmountOfFuel, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires, k_MaxAmountOfFuel)
        {
            m_Properties.Add(new Property("Max amount of fuel", typeof(float)), k_MaxAmountOfFuel);
            m_Car = i_Car;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Max amount of fuel: {2} {1}{3}", base.ToString(), System.Environment.NewLine, k_MaxAmountOfFuel, m_Car.ToString());
        }
    }
}
