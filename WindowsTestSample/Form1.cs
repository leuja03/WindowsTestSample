using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;

namespace WindowsTestSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum BitType
        {
           None = 0,
           One = 1 << 0,
           Two = 1 << 1,
           Three = 1 << 2,
           Four = 1 << 3,
           Five = 1 << 4,
           Six = 1 << 5,
           Seven = 1 << 6,
           Eight = 1 << 7,
           Nine = 1 << 8,
           Ten = 1 << 9,
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string result = Test_StaticClass_AltWay.WhatToGet();

           TestFactory();

           // Test bits
           int value = 3;
           TestAndValue(value);
           value = 4;
           TestAndValue(value);
           value = 10;
           TestAndValue(value);
           value = 32;
           TestAndValue(value);
           value = 59;
           TestAndValue(value);
           value = value << 2;


            List<string> thisList = new List<string>();
            int count = thisList.Count;
            count = thisList.Capacity;
        }

        private void TestAndValue(int value)
        {
           int testvalue = value & (int)BitType.One;
           testvalue = value & (int)BitType.Two;
           testvalue = value & (int)BitType.Three;
           testvalue = value & (int)BitType.Four;
           testvalue = value & (int)BitType.Five;
           testvalue = value & (int)BitType.Six;
           testvalue = value & (int)BitType.Seven;
           testvalue = value & (int)BitType.Eight;
        }

        private void TestFactory()
        {
           var servA = MyServiceFactoryA.CreateStubWithTemperature(45);
           var servB = MyServiceFactoryB.CreateStubWithContents("test string");
           var myClass = MyClassFactory.CreateEmpty().WithService(servA).WithOtherService(servB);
        }

        private void TestClasses()
        {
           A aa = Product.Give();
           string result = aa.MethodA();
           B bb = (B)Product.Give();
           result = bb.MethodA();
        }

        private void TestURL()
        {
           string destinationURL = "http://www.contoso.com/default.aspx?user=test";
           string testUrl = HttpContext.Current.Server.UrlEncode(destinationURL);
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
      public MyClass()
      {
      }
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
      public static MyClass Create(IServiceA a, IServiceB b)
      {
         return new MyClass(a, b);
      }
      public static MyClass CreateEmpty()
      {
         return new MyClass();
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




    public class Product
    {
        public static A Give()
        {
            return new A();
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
