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

        public List<SerializedCar> Cars { get; set; } = new List<SerializedCar>();
    }

    [Serializable]
    public class SerializedCar
    {

        public static implicit operator SerializedCar(Car car)
        {
            SerializedCar serializedCar = new SerializedCar();
            serializedCar.VIN = car.VIN;
            serializedCar.ProductionYear = car.ProductionYear;
            serializedCar.Model = car.Model;
            return serializedCar;
        }

        public string VIN { get; set; }

        public int ProductionYear { get; set; }

        public string Model { get; set; }
    }
}