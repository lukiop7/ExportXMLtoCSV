using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Xsl;
using ExportXMLtoCSV.ObjectClasses;

namespace ExportXMLtoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ProductionReport));
            using (FileStream fileStream = new FileStream(@"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\ProductionResults.xml", FileMode.Open))
            {
                ProductionReport result = (ProductionReport)deserializer.Deserialize(fileStream);
                SerializedCars serializedCars = new SerializedCars();
                serializedCars.Manufacturer = result.Manufacturer;
                serializedCars.Date = result.Date;
                foreach(Factory factory in result.Factories){
                    foreach (Car car in factory.Cars)
                    {
                        serializedCars.Cars.Add(car);
                    }
                }
                XmlSerializer serializer = new XmlSerializer(typeof(SerializedCars));

                var textWriter = new StreamWriter(@"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\config.xml");
                serializer.Serialize(textWriter, serializedCars);
                textWriter.Close();

                XslCompiledTransform transform = new XslCompiledTransform();
                transform.Load(@"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\TransformToCsv.xslt");
                transform.Transform(@"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\config.xml", @"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\output.csv");
            }
        }
    }
}
