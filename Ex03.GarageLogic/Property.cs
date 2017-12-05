using System;

namespace Ex03.GarageLogic
{
    public class Property
    {
        public string m_DescriptionOfArgument;
        public Type m_Type;

        public Property(string i_DescriptionArgument, Type i_Type)
        {
            m_DescriptionOfArgument = i_DescriptionArgument;
            m_Type = i_Type;
        }

        public string Description
        {
            get
            {
                return m_DescriptionOfArgument;
            }
        }

        public Type Type
        {
            get
            {
                return m_Type;
            }
        }
    }
}
