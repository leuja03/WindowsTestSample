using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public static class CheckDefaultTest
   {
      public static void DoTest()
      {
         CheckDefault<int> test = new CheckDefault<int>();
         object result = test.Result;

         CheckDefault<string> stringtest = new CheckDefault<string>();
         result = stringtest.Result;

         CheckDefault<int?> nullable = new CheckDefault<int?>();
         result = nullable.Result; // null

         CheckDefault<TestStruct> structs = new CheckDefault<TestStruct>();
         result = structs.Result;
         result = new TestStruct(1, 2.2, "3", null, null);
         result = default(TestStruct);

         CheckDefault<TestClass> classs = new CheckDefault<TestClass>();
         result = classs.Result;


      }
   }

   public class CheckDefault<TDefault>
   {
      public CheckDefault()
      {
         Result = default(TDefault);
      }

      public TDefault Result { get; set; }
   }

   public struct TestStruct
   {
      int First ;
      double Second ;
      string Third ;
      decimal? Fourth ;
      int? Fifth ;

      public TestStruct(int f1, double s2, string t3, decimal? f4, int? f5)
      {
         First = f1;
         Second = s2;
         Third = t3;
         Fourth = f4;
         Fifth = f5;
      }
   }

   public class TestClass
   {
      public int First;
      public string Second;
      public int? Third;
      public TestStruct Fourth;
   }
}
