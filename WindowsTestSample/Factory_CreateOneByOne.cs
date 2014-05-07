using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTestSample
{
   /// <summary>
   /// A class to do testing
   /// </summary>
   public class Factory_CreateOneByOne
   {
      public static void TestFactory()
      {
         var servA = MyServiceFactoryA.CreateStubWithTemperature(45);
         var servB = MyServiceFactoryB.CreateStubWithContents("test string");
         var myClass = MyClassFactory.CreateEmpty().WithService(servA).WithOtherService(servB);
      }
   }


   public interface IServiceA
   {
      void DoA();
   }

   public interface IServiceB
   {
      void DoB();
   }

   public class MyClass
   {
      IServiceA m_a;
      IServiceB m_b;

      public MyClass() { }

      public MyClass(IServiceA a, IServiceB b)
      {
         m_a = a;
         m_b = b;
      }

      public IServiceA SerA
      {
         get { return m_a; }
         set { m_a = value; }
      }

      public IServiceB SerB
      {
         get { return m_b; }
         set { m_b = value; }
      }
   }

   public static class MyClassExtensions
   {
      public static MyClass WithService(this MyClass @this, IServiceA a)
      {
         @this.SerA = a;
         return @this;
      }
      public static MyClass WithOtherService(this MyClass @this, IServiceB b)
      {
         @this.SerB = b;
         return @this;
      }
   }

   public class MyClassFactory
   {
      public static MyClass CreateEmpty()
      {
         return new MyClass();
      }
      public static MyClass Create(IServiceA a, IServiceB b)
      {
         return new MyClass(a, b);
      }
   }

   public class ServiceA : IServiceA
   {
      public void DoA()
      {
         // do a
      }
   }
   public class ServiceB : IServiceB
   {
      public void DoB()
      {
         // do b
      }
   }

   public class MyServiceFactoryA
   {
      public static ServiceA CreateStubWithTemperature(int a)
      {
         return new ServiceA();
      }
   }

   public class MyServiceFactoryB
   {
      public static ServiceB CreateStubWithContents(string a)
      {
         return new ServiceB();
      }
   }
}
