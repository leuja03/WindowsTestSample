using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTestSample
{
   public class Check_Inheritance
   {
      public static void DoTest()
      {
         TestClasses();
      }

      private static void TestClasses()
      {
         A a = new A();
         string str = a.MethodA();
         B b = new B();
         str = b.MethodA();
         a = b;
         str = a.MethodA();


         A aa = Product.Give();
         string result = aa.MethodA();
         B bbb = Product.GiveB();
         result = bbb.MethodA();
         B bb = Product.Give() as B;
         //result = bb.MethodA();
      }

      public class Product
      {
         public static A Give()
         {
            return new A();
         }

         public static B GiveB()
         {
            return new B();
         }
      }
      public class A
      {
         public virtual string MethodA()
         {
            return "A";
         }

      }
      public class B : A
      {
         public override string MethodA()
         {
            return "B";
         }
      }
   }
}
