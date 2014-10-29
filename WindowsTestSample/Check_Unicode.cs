using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTestSample
{
   class Check_Unicode
   {
      public static void DoTest()
      {
         string regular = "This is good";
         string unicode = "這是件 好事";
         string mixed = "這是 ok 事 end";

         bool result = AnyUnicodeCharacter(regular);
         result = AnyUnicodeCharacter(unicode);
         result = AnyUnicodeCharacter(mixed);
      }

      public static bool AnyUnicodeCharacter(string input)
      {
         const int maxAnsiCode = 255;
         return input.Any(c => c > maxAnsiCode);
      }
   }
}
