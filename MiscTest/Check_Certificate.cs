using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Certificate
   {
      public static void DoTest()
      {
         new TheCertificateClass().RunThis();
      }
   }

   internal class TheCertificateClass
   {
      public void RunThis()
      {
         X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
         store.Open(OpenFlags.ReadOnly);
         X509Certificate2Collection certCollection = store.Certificates;
         foreach (X509Certificate2 cert in certCollection)
         {
         }
         store.Close();
      }
   }
}
