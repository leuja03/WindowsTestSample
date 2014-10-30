using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Test_StaticClass_AltWay
   {
      public static void DoTest()
      {
         string result = GetString();
      }

      private static string GetString()
      {
         string testC1 = C1.Instance.WriteLine();
         return testC1;
      }
   }

   /// <summary>
   /// http://blogs.codes-sources.com/matthieu/archive/2008/02/20/override-static.aspx
   /// </summary>
   /// <typeparam name="T"></typeparam>
   abstract class BaseStaticOverride<T> where T : BaseStaticOverride<T>
   {
      private static T _instance;
      private static object _lock = new object();

      public static T Instance
      {
         get
         {
            if (_instance == null)
            {
               lock (_lock)
               {
                  if (_instance == null)
                     _instance = (T)Activator.CreateInstance(typeof(T), true);
               }
            }
            return _instance;
         }
      }
   }
   abstract class C1Base<T> : BaseStaticOverride<T> where T : C1Base<T>
   {
      protected C1Base()
      {
      }

      public string WriteLine()
      {
         return Line;
      }
      protected abstract string Line
      {
         get;
      }
   }
   class C1 : C1Base<C1>
   {
      private C1()
      {
      }

      protected override string Line
      {
         get { return "C1"; }
      }
   }
   class C2 : C1Base<C2>
   {
      private C2()
      {
      }

      protected override string Line
      {
         get { return "C2"; }
      }
   }
}
