using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private Motorcycle m_Motorcycle;
        public const float k_MaxAmountOfFuel = 7.2f;

        public FuelMotorcycle(Motorcycle i_Motorcycle, FuelVehicle.eFuelType i_FuelType, float i_CurrentAmountOfFuel, string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
            : base(i_FuelType, i_CurrentAmountOfFuel, i_Model, i_LicensePlateNumber, i_PercentOfRemainingEnergy, i_Tires, k_MaxAmountOfFuel)
        {
            m_Properties.Add(new Property("Max amount of fuel", typeof(float)), k_MaxAmountOfFuel);
            m_Motorcycle = i_Motorcycle;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}Max amount of fuel: {2} {1}{3}", base.ToString(), System.Environment.NewLine, k_MaxAmountOfFuel, m_Motorcycle.ToString());
        }
    }
}
