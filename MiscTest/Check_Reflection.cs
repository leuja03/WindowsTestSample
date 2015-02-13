using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Reflection
   {
      public static void DoTest()
      {
         TestClass_Reflection obj = new TestClass_Reflection();

         Type ty = typeof(TestClass_Reflection);
         PropertyInfo[] pinfos = ty.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
         PropertyInfo pinfo = obj.GetType().GetProperty("GetPrivateString", BindingFlags.NonPublic | BindingFlags.Instance);
         object value = pinfo.GetValue(obj);



         Type t = typeof(PropertyClass);
         // Get the public properties.
         PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
         // Display the public properties.
         //DisplayPropertyInfo(propInfos);

         // Get the nonpublic properties.
         PropertyInfo[] propInfos1 = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
         // Display all the nonpublic properties.
         //DisplayPropertyInfo(propInfos1);

         // Get the all fields.
         FieldInfo[] fieldInfos1 = typeof(FieldClass).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
         // Display all the nonpublic properties.
         //DisplayPropertyInfo(propInfos1);

         // Get the all fields.
         FieldInfo[] fieldInfos2 = typeof(StaticMembersClass).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
         // Display all the nonpublic properties.
         //DisplayPropertyInfo(propInfos1);
      }
   }

   public class TestClass_Reflection
   {
      private int PrivateInt = 10;
      private string PrivateString = "private this ";

      public TestClass_Reflection()
      {
      }

      public int GetPrivateInt
      {
         get { return PrivateInt; }
         set { PrivateInt = value; }
      }

      protected string GetPrivateString
      {
         get { return PrivateString; }
         set { PrivateString = value; }
      }

      public int PublicMethod()
      {
         return 1111;
      }

      protected string ProtectedMethod()
      {
         return "protected string";
      }

   }


   public class PropertyClass
   {
      public String Property1
      {
         get { return "hello"; }
      }

      public String Property2
      {
         get { return "hello"; }
      }

      protected String Property3
      {
         get { return "hello"; }
      }

      private Int32 Property4
      {
         get { return 32; }
      }

      internal String Property5
      {
         get { return "value"; }
      }

      protected internal String Property6
      {
         get { return "value"; }
      }
   }

   public class FieldClass
   {
      private string m_privateString1 = "string 1";
      protected string m_protectedString2 = "string 2";
      internal string m_internalString3 = "string 3";
      public string m_publicString4 = "string 4";

      public static string m_staticPublicString5 = "string 5";
   }

   public class StaticMembersClass
   {
      private static string m_privateString1 = "string 1";
      protected static string m_protectedString2 = "string 2";
      internal static string m_internalString3 = "string 3";
      public static string m_publicString4 = "string 4";

      public string m_publicString5 = "string 5";
   }
}
