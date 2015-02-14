using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_AppConfig_Protection
   {
      public static void DoTest()
      {
         new TheProtection().DoSomeProtection();
      }
   }

   internal class TheProtection
   {
      public void DoSomeProtection()
      {
         string value = "";// ConfigurationManager.AppSettings["AAA"];
         NameValueCollection settings = ConfigurationManager.GetSection("appSettings") as NameValueCollection;
         value = settings.Get("AAA");

         Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
         config.AppSettings.Settings.Add("TestAdd", "TestValue");
         config.Save(ConfigurationSaveMode.Modified);


         AppSettingsSection appSec = config.GetSection("appSettings") as AppSettingsSection;
         //appSec.SectionInformation.ProtectSection(null);
         //appSec.SectionInformation.ForceSave = true;
         //config.Save();

         string check = appSec.SectionInformation.GetRawXml();

      }
   }
}
