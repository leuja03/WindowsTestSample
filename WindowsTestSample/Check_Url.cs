using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WindowsTestSample
{
   public class Check_Url
   {
      public static void DoTest()
      {
         TestURL();
      }

      private static void TestURL()
      {
         string destinationURL = "http://www.contoso.com/default.aspx?user=test";
         string testUrl = HttpContext.Current.Server.UrlEncode(destinationURL);
      }
   }
}
