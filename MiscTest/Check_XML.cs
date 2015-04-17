using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MiscTest
{
   public class Check_XML
   {
      public static void DoTest()
      {
         // export xml
         //ExportXml();

         // parse xml file
         //ParseXml();
         ForecastXmlData xmlData = new ForecastXmlData();
         xmlData.data = new List<ForecastData>();
         xmlData.data.Add(new ForecastData() { Name = "current", Temperature = "15", Unit = "c", High = "20", Low = "10", Humidity = "70" });
         xmlData.data.Add(new ForecastData() { Name = "monday", Temperature = "16", Unit = "c", High = "21", Low = "11", Humidity = "65" });
         xmlData.data.Add(new ForecastData() { Name = "tuesday", Temperature = "17", Unit = "c", High = "22", Low = "12", Humidity = "61" });
         ExportXml2(xmlData);
      }

      private static void ParseXml()
      {
         string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "forecast_attributes.xml";

         XDocument xml = XDocument.Load(filePath);
         var elements = (from element in xml.Root.Elements("day")
                         where (string)element.Attribute("name") == "current"
                         select new
                         {
                            Name = (string)element.Attribute("name"),
                            Temperature = (string)element.Attribute("temperature"),
                            Degree = (string)element.Attribute("degree"),
                         }).ToList();
      }

      [XmlRootAttribute("forecast")]
      public class ForecastXmlData
      {
         [XmlElement("day")]
         public List<ForecastData> data;
      }
      [XmlRootAttribute("day")]
      public class ForecastData
      {
         [XmlAttribute("name")]
         public string Name;
         [XmlAttribute("temperature")]
         public string Temperature;
         [XmlAttribute("degree")]
         public string Unit;
         [XmlAttribute("high")]
         public string High;
         [XmlAttribute("low")]
         public string Low;
         [XmlAttribute("humidity")]
         public string Humidity;
      }

      private static void ExportXml2(ForecastXmlData dataList)
      {
         //List<ThresholdData> converted = ConvertTo(dataList);
         string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "forecast_attributes22.xml";
         string tryFile = filePath;
         using (StreamWriter writer = new StreamWriter(tryFile, false, Encoding.Unicode))
         {
            XmlSerializer serializer = new XmlSerializer(typeof(ForecastXmlData));
            serializer.Serialize(writer, dataList);
         }
      }

      private static void ExportXml()
      {
         string outputPath = @"F:\__Simply DBs__\2014\cdn\Manulife\test.xml";
         using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding(1252)))
         {
            ROEWebData dataList = new ROEWebData();
            dataList.version = "1.2";
            dataList.nonexposed = "abcdef";
            dataList.data = new List<ROEData>();

            ROEData data = new ROEData();
            data.sin = "1";
            data.sin2 = "2";
            dataList.data.Add(data);
            data = new ROEData();
            data.sin = "1111";
            data.sin2 = "2222";
            dataList.data.Add(data);

            XmlSerializer serializer = new XmlSerializer(typeof(ROEWebData));
            serializer.Serialize(writer, dataList);
         }
      }


      [XmlRootAttribute("root1")]
      public class ROEWebData
      {
         public const int non_exposed_num = 1;

         [XmlAttribute]
         public string version;
         public string nonexposed;
         [XmlElement("roe")]
         public List<ROEData> data;
      }
      public class ROEData
      {
         [XmlElement("Elem1")]
         public string sin;
         [XmlElement("Elem2")]
         public string sin2;
      }
   }
}
