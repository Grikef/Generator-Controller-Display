using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            public byte openedMode = 0x2;
            
            public Power power;
            public Voltage voltage;
            public Current current;

            private XML_Serialization XmlSerialization = new XML_Serialization();

            public void SerializeCurrentOptions()
            {
                XmlSerialization.StoreSerialize(this);
            }

            public Net DeserializeOptions()
            {
                return XmlSerialization.DeserializeNet("Store.xml");
            }
        }
        
        [Serializable, XmlRoot("engine")]
        public class Engine : Net
        {
            
            private XML_Serialization XmlSerialization = new XML_Serialization();

            public OilPressure oilPressure;
            public OilTemperature oilTemperature;

            public EngineTemperature engineTemperature;

            public CasingTemperature casingTemperature;

            public Fuel fuel;

            public Engine()
            {
                power = new Power();
                voltage = new Voltage();
                current = new Current();
                
                oilPressure = new OilPressure();
                oilTemperature = new OilTemperature();
                engineTemperature = new EngineTemperature();
                casingTemperature = new CasingTemperature();

                fuel = new Fuel();
            }

            public Engine DeserializeOptions()
            {
               return XmlSerialization.DeserializeEngine("Store.xml");
            }
        }

        [Serializable]
        public class Generator : Engine
        {
            private XML_Serialization XmlSerialization = new XML_Serialization();
            public Generator()
            {
                power = new Power();
                voltage = new Voltage();
                current = new Current();
                
                oilPressure = new OilPressure();
                oilTemperature = new OilTemperature();
                engineTemperature = new EngineTemperature();
                casingTemperature = new CasingTemperature();

                fuel = new Fuel();
            }
            
            
            public Generator DeserializeOptions()
            {
                return XmlSerialization.DeserializeGenerator("Store.xml");
            }
        }
    }
}
