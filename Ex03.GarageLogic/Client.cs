namespace Ex03.GarageLogic
{
    public class Client
    {
        public string m_OwnerName;
        public string m_PhoneNumberOfOwner;
        public eVehicleStatus m_VehicleStatus;
        public Vehicle m_Vehicle;

        public enum eVehicleStatus
        {
            Repairing = 1,
            Repaired = 2,
            Paid = 3,
            none = 4
        }

        public Client(string i_OwnerName, string i_PhoneNumberOfOwner, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            this.m_VehicleStatus = i_VehicleStatus;
            this.m_Vehicle = i_Vehicle;
        }

        public override string ToString()
        {
            return string.Format("Owner name: {0} {3}Phone number: {1} {3}Vehicle status: {2}", m_OwnerName, m_PhoneNumberOfOwner, m_VehicleStatus, System.Environment.NewLine);
        }
    }
}
