using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Thread
{
   class AsyncTask
   {
      public static async Task<string> SaySomething()
      {
         await Task.Delay(10);

         Thread_Main.CommonResource = "hello world";

         return "something";
      }
   }
}
