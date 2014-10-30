using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Regex
   {
      public static void DoTest()
      {
         TestRegex();
      }

      private static void TestRegex()
      {
         string req = @"^(1|2)$";

         // country
         bool
         regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("2", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("3", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("A", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);

         // client id
         req = @"^[0-9]{10}$";
         regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("A", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("BCD dsfasf", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("1234567890", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("12345678901", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("123456789A", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);

         // date
         req = @"^[0-9]{6}$";
         regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("1234567", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("1 4 52", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("123456", req, RegexOptions.IgnoreCase);
         regexResult = Regex.IsMatch("1AB567", req, RegexOptions.IgnoreCase);

         // version
         req = @"^[0-9]{6}$";
         regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);
      }

   }
}
