using System;
using System.Threading.Tasks;
using Check_Thread;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Check_Thread_UnitTest
{
   [TestClass]
   public class Async_Test
   {
      // https://msdn.microsoft.com/en-us/magazine/dn818493.aspx

      [TestMethod]
      [TestCategory("AsyncTest")]
      public async Task TestTheAsync()
      {
         CallAyncClass asyncObj = new CallAyncClass();
         await asyncObj.EnterThisClass();

         Assert.AreEqual("In <SaySomethingElse()>, doing sth...110", Thread_Main.CommonResource);

         await asyncObj.SaySomethingElse();

         Assert.AreEqual("In <SaySomethingElse()>, doing sth...", Thread_Main.CommonResource);

      }
   }
}
