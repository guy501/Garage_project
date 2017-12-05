namespace Ex03.GarageLogic
{
    public class Car
    {
        public eColor m_Color;
        public eNumberOfDoors m_NumberOfDoors;

        public enum eColor
        {
            Yellow,
            White,
            Red,
            Black,
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public Car(eColor i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public static void setProperties(Vehicle vehicle, eColor i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            vehicle.m_Properties.Add(new Property("Car color", typeof(eColor)), i_Color);
            vehicle.m_Properties.Add(new Property("Number of doors", typeof(eNumberOfDoors)), i_NumberOfDoors);
        }

        public override string ToString()
        {
            return string.Format("Car color: {1} {0}Number of doors: {2}", System.Environment.NewLine, m_Color, m_NumberOfDoors);
        }
    }
}