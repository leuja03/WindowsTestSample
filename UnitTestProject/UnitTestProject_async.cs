using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
   [TestClass]
   public class UnitTestProject_async
   {
      [TestMethod]
      [TestCategory("async test")]
      //[TestProperty("property", "the first async test")]
      public async void TestAsyncException()
      {
         //Assert.ThrowsException
         await AssertExtensions.ThrowsExceptionAsync<ArgumentException>
            (
            async () =>
               {
                  await Task.Run(() =>
                     {
                        throw new Exception("try this exception");
                     });
            }
         );
      }

      [TestMethod]
      [TestCategory("general exception test")]
      public void TestException()
      {
         AssertExtensions.ThrowsExceptionAsync<NullReferenceException>
            (
            () => { throw new NullReferenceException("try this null exception"); }
            );
      }
   }

   public static class AssertExtensions
   {
      public static Task<T> ThrowsExceptionAsync<T>(Func<Task> action) where T : Exception
      {
         return ThrowsExceptionAsync<T>(action, string.Empty, null);
      }

      public static Task<T> ThrowsExceptionAsync<T>(Func<Task> action, string message) where T : Exception
      {
         return ThrowsExceptionAsync<T>(action, message, null);
      }

      public async static Task<T> ThrowsExceptionAsync<T>(Func<Task> action, string message, object[] parameters) where T : Exception
      {
         try
         {
            await action();
         }
         catch (Exception e)
         {
            if (e.GetType() == typeof(T))
            {
               return e as T;
            }

            var objArray = new object[] 
            {               
            };

            throw new AssertFailedException(message);
         }

         throw new AssertFailedException(message);
      }
   }
}
