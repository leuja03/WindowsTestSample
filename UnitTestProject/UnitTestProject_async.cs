using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
   [TestClass]
   public class UnitTestProject_async
   {
      /// <summary>
      /// https://msdn.microsoft.com/en-us/magazine/dn818493.aspx
      /// 
      /// reference: https://msdn.microsoft.com/en-us/magazine/dn818494.aspx
      /// </summary>
      /// <returns></returns>
      [TestMethod]
      [TestCategory("async test")]
      public async Task CorrectlyFailingTest()
      {
         await SystemToBeTested.SimpleAsync();
      }


      [TestMethod]
      [TestCategory("async test")]
      //[TestProperty("property", "the first async test")]
      public async Task TestAsyncException()
      {
         //Assert.ThrowsException
         await AssertExtensions.ThrowsExceptionAsync<ArgumentException>
            (
            async () =>
               {
                  await Task.Run(() =>
                     {
                        throw new Exception("try this async exception");
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
            () => { throw new NullReferenceException("try this regular exception"); }
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
