namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        public enum eTypeOfLicense
        {
            A,
            A1,
            AB,
            B1,
        }

        public eTypeOfLicense m_TypeOfLicense;
        public int m_EngineCapacity;

        public Motorcycle(eTypeOfLicense i_TypeOfLicense, int i_EngineCapacity)
        {
            this.m_TypeOfLicense = i_TypeOfLicense;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public static void setProperties(Vehicle vehicle, eTypeOfLicense i_TypeOfLicense, int i_EngineCapacity)
        {
            vehicle.m_Properties.Add(new Property("Type of license", typeof(eTypeOfLicense)), i_TypeOfLicense);
            vehicle.m_Properties.Add(new Property("Engine capacity", typeof(int)), i_EngineCapacity);
        }

        public override string ToString()
        {
            return string.Format("Type of license: {1} {0}Engine capacity: {2}", System.Environment.NewLine, m_TypeOfLicense, m_EngineCapacity);
        }
    }
}
