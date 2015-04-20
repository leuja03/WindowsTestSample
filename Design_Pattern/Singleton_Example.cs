using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern
{
   /// <summary>
   /// This is thread-safe and fast!!
   /// - From Pluralsight: Design Pattern Library
   /// </summary>
   public class Singleton_ThreadSafeFast
   {
      #region Singleton Pattern
      private Singleton_ThreadSafeFast()
      {
      }

      public static Singleton_ThreadSafeFast Instance
      {
         get { return Nested.Instance; }
      }

      private class Nested
      {
         static Nested()
         {
         }

         internal static readonly Singleton_ThreadSafeFast Instance = new Singleton_ThreadSafeFast();
      }
      #endregion


      #region Other Public operations
      public void DoSomething()
      {
      }
      #endregion
   }
}
