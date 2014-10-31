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
         string req = string.Empty;
         bool regexResult = false;

         // country
         req = @"^(1|2)$";
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

         // Test custom range
         TestCustom();



         // misc
         TestMisc();
      }

      private static void TestCustom()
      {
         // only selected list
         List<string> stringList = new List<string>() { "CA", "US", "XX" };
         bool listResult = false;
         foreach (string content in stringList)
         {
            listResult = Regex.IsMatch(content, @"^(CA|US)$");
         }


         // Test SIN
         string testSIN = "123456789";
         string SIN_requirement = @"^[0-9]+$";
         listResult = Regex.IsMatch(testSIN, SIN_requirement);
         testSIN = "123 45678";
         listResult = Regex.IsMatch(testSIN, SIN_requirement);
      }

      private static void TestMisc()
      {
         string a = "abc123";
         string b = "333hfdg";
         string c = "dsafk2343kasdf";
         string d = "234adfds566dsfa233444";
         string f = "111 aaa";
         string g = "bbb 222";
         var regex = Regex.Match(a, @"\d+");
         var result = regex.ToString();
         regex = Regex.Match(b, @"\d+");
         result = regex.ToString();
         regex = Regex.Match(c, @"\d+");
         result = regex.ToString();
         regex = Regex.Match(d, @"\d+");
         result = regex.ToString();
         regex = Regex.Match(f, @"\d+");
         result = regex.ToString();
         regex = Regex.Match(g, @"\d+");
         result = regex.ToString();
      }

   }
}
