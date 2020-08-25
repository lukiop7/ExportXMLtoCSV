using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Serialization;

namespace ExportXMLtoCSV
{
    namespace ObjectClasses
    {
        [XmlRoot("ProductionReport")]
        public class ProductionReport
        {
            [XmlAttribute("Date")]
            public string Date { get; set; }

            [XmlAttribute("Manufacturer")]
            public string Manufacturer { get; set; }

            [XmlArray("Factories")]
            [XmlArrayItem("Factory")]
            public List<Factory> Factories { get; set; }
        }

        public class Factory
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }

            [XmlArray("ProducedCars")]
            [XmlArrayItem("Car")]
            public List<Car> Cars { get; set; }
        }

        public class Car
        {
            [XmlAttribute("VIN")]
            public string VIN { get; set; }

            public int ProductionYear { get; set; }

            public string Model { get; set; }

            [XmlArray("Features")]
            [XmlArrayItem("Feature")]
            public List<Feature> Features { get; set; }
        }

        public class Feature
        {
            [XmlAttribute("Code")] 
            public string Code { get; set; }


        }
    }
}
