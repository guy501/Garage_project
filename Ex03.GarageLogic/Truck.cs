namespace Ex03.GarageLogic
{
    public class Truck
    {
        public bool m_CarrierDangerousMaterials;
        public float m_MaximumCarryingWeight;

        public Truck(bool i_CarrierDangerousMaterials, float i_MaximumCarryingWeight)
        {
            this.m_CarrierDangerousMaterials = i_CarrierDangerousMaterials;
            this.m_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public static void setProperties(Vehicle vehicle, bool i_CarrierDangerousMaterials, float i_MaximumCarryingWeight)
        {
            vehicle.m_Properties.Add(new Property("Carrier dangerous materials", typeof(bool)), i_CarrierDangerousMaterials);
            vehicle.m_Properties.Add(new Property("Maximum carrying weight", typeof(float)), i_MaximumCarryingWeight);
        }

        public override string ToString()
        {
            return string.Format("Carrier dangerous materials: {1} {0}Maximum carrying weight: {2}", System.Environment.NewLine, m_CarrierDangerousMaterials, m_MaximumCarryingWeight);
        }
    }
}
