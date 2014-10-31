using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Ping
   {
      public static void DoTest()
      {
         Ping_Test();
      }

      private static void Ping_Test()
      {
         Ping pingSender = new Ping();
         PingOptions options = new PingOptions();

         // Use the default Ttl value which is 128, 
         // but change the fragmentation behavior.
         options.DontFragment = true;

         // Create a buffer of 32 bytes of data to be transmitted. 
         string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
         byte[] buffer = Encoding.ASCII.GetBytes(data);
         int timeout = 120;

         string hostname = "bcr512228";
         //string hostname = "bcr512060";//"localhost";

         try
         {
            PingReply reply = pingSender.Send(hostname, timeout, buffer, options);
            string result = string.Empty;
            if (reply.Status == IPStatus.Success)
            {
               result += string.Format("Address: {0}", reply.Address.ToString()) + "\n";
               result += string.Format("RoundTrip time: {0}", reply.RoundtripTime) + "\n";
               result += string.Format("Time to live: {0}", reply.Options.Ttl) + "\n";
               result += string.Format("Don't fragment: {0}", reply.Options.DontFragment) + "\n";
               result += string.Format("Buffer size: {0}", reply.Buffer.Length) + "\n";
            }
         }
         catch (Exception e)
         {
            string exceptionMsg = e.Message;
         }
      }
   }
}
