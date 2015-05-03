using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public static class CheckDefaultTest
   {
      public static void DoTest()
      {
         // numeric
         CheckDefault<int> test = new CheckDefault<int>();
         object result = test.Result;

         // string
         CheckDefault<string> stringtest = new CheckDefault<string>();
         result = stringtest.Result;

         // nullable value type
         CheckDefault<int?> nullable = new CheckDefault<int?>();
         result = nullable.Result; // null

         // struct
         CheckDefault<TestStruct> structs = new CheckDefault<TestStruct>();
         result = structs.Result;
         result = new TestStruct(1, 2.2, "3", null, null);
         result = default(TestStruct);

         // reference type
         CheckDefault<TestClass> classs = new CheckDefault<TestClass>();
         result = classs.Result;



         // Test self-defined default value in reference type
         CheckDefault<TestDefaultClass> customDefaultClass = new CheckDefault<TestDefaultClass>();
         result = classs.Result;
         // constructor
         TestDefaultClass customValueClass = new TestDefaultClass();
         bool testValue = customValueClass.MyProperty;
         testValue = customValueClass.MyProperty2;
         testValue = customValueClass.Second;
         testValue = customValueClass.Third;

         // well... the default value attribute is pretty useless!!!!!
         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(customValueClass);
         AttributeCollection attributes = collection["MyProperty2"].Attributes;
         DefaultValueAttribute myAttribute = attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
         string defaultValue = myAttribute.Value.ToString();
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
      // cannot initialize field in struct
      //int No_Initializer = 1;

      // Cannot define a parameterless constructor/default constructor
      //public TestStruct() {}

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

   public class TestDefaultClass
   {
      private bool myvalue = false;
      private bool myvalue2;
      private bool second;

      [DefaultValue(true)] // this has no effect because the value is defined earlier
      public bool MyProperty
      {
         get { return myvalue; }
         set { myvalue = value; }
      }

      [DefaultValue(true)]
      public bool MyProperty2
      {
         get { return myvalue2; }
         set { myvalue2 = value; }
      }

      public bool Second
      {
         get { return second; }
         set { second = value; }
      }

      [DefaultValue(true)]
      public bool Third
      {
         get;
         set;
      }
   }
}
