using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ExportXMLtoCSV.ObjectClasses;

namespace ExportXMLtoCSV
{
    [Serializable]
    public class SerializedCars
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }


        public List<Car> Cars { get; set; } = new List<Car>();
    }

}