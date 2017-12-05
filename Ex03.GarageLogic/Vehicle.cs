using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        public Dictionary<Property, object> m_Properties = new Dictionary<Property, object>();
        public string m_Model;
        public string m_LicensePlateNumber;
        public float m_PercentOfRemainingEnergy;
        public List<Tire> m_Tires;

        public enum eTireAmount
        {
            Motorcycle = 2,
            Car = 4,
            Truck = 16,
        }

        public Vehicle(string i_Model, string i_LicensePlateNumber, float i_PercentOfRemainingEnergy, List<Tire> i_Tires)
        {
            this.m_Model = i_Model;
            this.m_LicensePlateNumber = i_LicensePlateNumber;
            this.m_PercentOfRemainingEnergy = i_PercentOfRemainingEnergy;
            this.m_Tires = i_Tires;
            m_Properties.Add(new Property("Model name", typeof(string)), i_Model);
            m_Properties.Add(new Property("License plate", typeof(string)), i_LicensePlateNumber);
            m_Properties.Add(new Property("Percent of remaining energy", typeof(float)), i_PercentOfRemainingEnergy);
        }

        public static float getPercentOfEnergy(float i_CurrentEnergy, float i_MaxEnergy)
        {
            float percentOfEnergy = i_CurrentEnergy * 100 / i_MaxEnergy;
            return percentOfEnergy;
        }
        
        public override string ToString()
        {
            return string.Format("License plate: {0} {1}Vehicle model: {2} {1}Energy condition: {3}", m_LicensePlateNumber, System.Environment.NewLine, m_Model, m_PercentOfRemainingEnergy);
        }
    }
}
