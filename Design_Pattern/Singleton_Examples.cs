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
   /// 
   /// Explanation:
   ///   http://csharpindepth.com/articles/general/singleton.aspx
   /// </summary>
   public class Singleton_FullLazy
   {
      #region Singleton Pattern
      private Singleton_FullLazy()
      {
      }

      public static Singleton_FullLazy Instance
      {
         get { return Nested.Instance; }
      }

      private class Nested
      {
         static Nested()
         {
         }

         internal static readonly Singleton_FullLazy Instance = new Singleton_FullLazy();
      }
      #endregion


      #region Other Public operations
      public int DoSomething()
      {
         return 50;
      }
      #endregion
   }

   public class Singleton_MSLazyType
   {
      #region Singleton Pattern
      private Singleton_MSLazyType()
      {
      }

      public static Singleton_MSLazyType Instance
      {
         get { return lazy.Value; }
      }

      private static readonly Lazy<Singleton_MSLazyType> lazy = new Lazy<Singleton_MSLazyType>(() => new Singleton_MSLazyType());
      #endregion

      #region Public operations
      public int DoSomething()
      {
         return 101;
      }
      #endregion
   }
}
