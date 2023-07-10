using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class Store
    {
        public class Engine
        {
            public class Power
            {
                public double normal = 5.0;
                public double max = 5.5;
                public double minToWarning = 4.8;

                public double ConvertToHorse()
                {
                    throw new NotImplementedException();
                }
            }

            public class Voltage
            {
                public double normal = 230.0;
                public double dispersion = 15.0;
            }

            public class Current
            {
                public double normal = 27.0;
                public double dispersion = 2.0;
            }

            public class OilPressure
            {
                public double normal;
                public double dispersion;
            }

            public class EngineTemperature
            {
                public double normal;
                public double max;
                public double maxToWarning;
                public double ConvertToFahrenheit()
                {
                    throw new NotImplementedException();
                }
            }

            public class OilTemperature
            {
                public double normal;
                public double max;
                public double maxToWarning;
                public double ConvertToFahrenheit()
                {
                    throw new NotImplementedException();
                }
            }

            public class CasingTemperature
            {
                public double normal;
                public double max;
                public double maxToWarning;
                public double ConvertToFahrenheit()
                {
                    throw new NotImplementedException();
                }
            }

            public class Fuel
            {
                public double max = 15.0;
                public double min = 0.0;
                public double minToWarning = 2.0;
            }
        }

        public class Generator
        {

        }

        public class Net //?
        {

        }
    }
}
