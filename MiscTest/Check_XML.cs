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
         ParseXml();
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
