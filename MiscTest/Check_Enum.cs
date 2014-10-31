using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Enum
   {
      public static void DoTest()
      {
         Test_Enum();
      }


      public enum TestEnum
      {
         Default = 0,
         One = 1,
         Two = 2,
      };

      private static void Test_Enum()
      {
         bool enumSafe = Enum.IsDefined(typeof(TestEnum), 1);
         enumSafe = Enum.IsDefined(typeof(TestEnum), 1000);

         TestEnum thisEnum = TestEnum.Default;
         enumSafe = Enum.IsDefined(typeof(TestEnum), thisEnum);
         try
         {
            thisEnum = (TestEnum)1;
            thisEnum = (TestEnum)1000; // no exception for out of range value!
         }
         catch (Exception) 
         {
         }
      }
   }
}
