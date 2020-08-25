using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using ExportXMLtoCSV.ObjectClasses;

namespace ExportXMLtoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductionReport));
            using (FileStream fileStream = new FileStream(@"D:\Projekty_Wakacje\ExportXMLtoCSV\ExportXMLtoCSV\ExportXMLtoCSV\ProductionResults.xml", FileMode.Open))
            {
                ProductionReport result = (ProductionReport)serializer.Deserialize(fileStream);
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(result))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(result);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }
        }
    }
}
