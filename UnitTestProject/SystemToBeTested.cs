using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
   class SystemToBeTested
   {
      public static async Task SimpleAsync()
      {
         await Task.Delay(100);
         throw new Exception("this should fail because of exception");
      }
   }
}
