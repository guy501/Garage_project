namespace Ex03.GarageLogic
{
    public class Tire
    {
        public string m_Manufacturer;
        public float m_CurrentAirPressure;
        public float m_MaxAirPressure;

        public enum eMaxAirPressure
        {
            Motorcycle = 31,
            Car = 30,
            Truck = 28,
        }

        public Tire(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
                    {
            this.m_Manufacturer = i_Manufacturer;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public bool fillingAir(float i_AmountOfAirToFill)
        {
            bool theFillingSucceeded = false;
            if ((m_CurrentAirPressure + i_AmountOfAirToFill) <= m_MaxAirPressure)
            {
                theFillingSucceeded = true;
                m_CurrentAirPressure += i_AmountOfAirToFill;
            }

            return theFillingSucceeded;
        }
    }
}
