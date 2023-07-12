using System;

namespace Monitor;

public partial class Store
{
    [Serializable]
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

    [Serializable]
    public class Voltage
    {
        public double normal = 230.0;
        public double dispersion = 15.0;
    }

    [Serializable]
    public class Current
    {
        public double normal = 27.0;
        public double dispersion = 2.0;
    }

    [Serializable]
    public class OilPressure
    {
        public double normal;
        public double dispersion;
    }

    [Serializable]
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

    [Serializable]
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

    [Serializable]
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

    [Serializable]
    public class Fuel
    {
        public double max = 15.0;
        public double min = 0.0;
        public double minToWarning = 2.0;
    }
}