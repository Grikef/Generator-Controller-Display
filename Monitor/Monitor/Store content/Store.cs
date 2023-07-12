using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    [Serializable]
    public partial class Store
    {
        // Этим евреев пытали в Освенциме
        

        public Store()
        {
        }
        public Store(string path)
        {

        }

        private void Deserialize()
        {
            
        }
        
        [Serializable]
        public class Net //base class
        {
            public Power power;
            public Voltage voltage;
            public Current current;

            private XML_Serialization XmlSerialization = new XML_Serialization();

            public void Abc()
            {
                switch (this.GetType().Name)
                {
                    case "Net":
                        break;
                    case "Engine":
                        break;
                    case "Generator":
                        break;
                }
            }
        }
        
        [Serializable]
        public class Engine : Net
        {
            public OilPressure oilPressure;
            public OilTemperature oilTemperature;

            public EngineTemperature engineTemperature;

            public CasingTemperature casingTemperature;

            public Fuel fuel;
        }

        [Serializable]
        public class Generator : Engine
        {
           
        }
    }
}
