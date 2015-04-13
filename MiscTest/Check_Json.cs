using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Json
   {
      public static void DoTest()
      {
         ParseJson();
      }

      private static void ParseJson()
      {
         string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "forecast_attributes.json";

         using (StreamReader reader = new StreamReader(filePath))
         {
            string json = reader.ReadToEnd();
            dynamic objectList = JsonConvert.DeserializeObject(json);
            foreach (var item in objectList)
            {
               
            }
         }
      }
   }
}
