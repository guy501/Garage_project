using System;

namespace Ex03.GarageLogic
{
        public class ValueOutOfRangeException : Exception
        {
            public float m_MaxValue;
            public float m_MinValue;

            public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base()
            {
                m_MinValue = i_MinValue;
                m_MaxValue = i_MaxValue;
            }

            public ValueOutOfRangeException(Exception i_Exception, float i_MinValue, float i_MaxValue)
                : base(string.Format("Value out of range", i_MinValue, i_MaxValue), i_Exception)
            {
            }

            public override string Message
            {
                get
                {
                    return string.Format("Value must be in range: {0} to {1}!", m_MinValue, m_MaxValue);
                }
            }
        }
}