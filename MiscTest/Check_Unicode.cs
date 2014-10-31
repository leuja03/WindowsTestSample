using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Unicode
   {
      public static void DoTest()
      {
         string regular = "This is good";
         string unicode = "這是件 好事";
         string mixed = "這是 ok 事 end";
         string trythis = "™"; // alt + 0153
         string try1 = "Ö";

         bool result = AnyUnicodeCharacter(regular);
         result = AnyUnicodeCharacter(unicode);
         result = AnyUnicodeCharacter(mixed);
         result = AnyUnicodeCharacter(trythis);
         result = AnyUnicodeCharacter(try1);
      }

      public static bool AnyUnicodeCharacter(string input)
      {
         const int maxAnsiCode = 255;
         string result = string.Empty;

         foreach (char c in input)
         {
            int testint = c;
            result += testint.ToString() + "\n";
         }

         return input.Any(c => c > maxAnsiCode);
      }
   }
}
