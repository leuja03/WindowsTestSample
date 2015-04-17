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

         SaveJson();
      }

      //[Serializable]
      public class ForecastJsonData
      {
         [JsonProperty("forecast")]
         public ForecastDayData outer;
      }
      //[Serializable]
      public class ForecastDayData
      {
         [JsonProperty("day")]
         public List<ForecastData> data;
      }
      //[Serializable]
      public class ForecastData
      {
         [JsonProperty("name")]
         public string Name;
         [JsonProperty("temperature")]
         public string Temperature;
         [JsonProperty("degree")]
         public string Unit;
         [JsonProperty("high")]
         public string High;
         [JsonProperty("low")]
         public string Low;
         [JsonProperty("humidity")]
         public string Humidity;
      }

      private static void ParseJson()
      {
         string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "forecast_attributes.json";

         using (StreamReader reader = new StreamReader(filePath))
         {
            string json = reader.ReadToEnd();
            ForecastJsonData jsonData = JsonConvert.DeserializeObject<ForecastJsonData>(json);
            if (jsonData != null)
            {
               foreach (var item in jsonData.outer.data)
               {

               }
            }

            // another way

         }
      }

      private static void SaveJson()
      {
         string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "forecast_attributes_output.json";

         // create the object
         ForecastJsonData jsonData = new ForecastJsonData();
         jsonData.outer = new ForecastDayData();
         jsonData.outer.data = new List<ForecastData>();
         jsonData.outer.data.Add(
            new ForecastData() { Name = "current", Temperature = "15", Unit = "c", High = "20", Low = "10", Humidity = "70" });
         jsonData.outer.data.Add(
            new ForecastData() { Name = "monday", Temperature = "16", Unit = "c", High = "21", Low = "11", Humidity = "65" });

         string outputString = JsonConvert.SerializeObject(jsonData);

         using (StreamWriter writer = new StreamWriter(filePath))
         {
            writer.Write(outputString);
         }

         // test:
         using (StreamReader reader = new StreamReader(filePath))
         {
            string json = reader.ReadToEnd();
            jsonData = JsonConvert.DeserializeObject<ForecastJsonData>(json);
            if (jsonData != null)
            {
               foreach (var item in jsonData.outer.data)
               {

               }
            }
         }
      }

   }
}
