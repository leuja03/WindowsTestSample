using System;
using Check_Thread;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Check_Thread_UnitTest
{
   [TestClass]
   public class Thread_Test
   {
      [TestMethod]
      public void ShouldUpdateTheStatusWhenDoAsync()
      {
         // Arrange 
         DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
         SystemUnderTest sut = new SystemUnderTest(taskScheduler);
         Assert.AreEqual("Nothing done", sut.Status);

         // Act
         sut.DoAsync(); // starts a new task and returns immediately
         Assert.AreEqual("Starting task", sut.Status);
         // Now execute the new task
         taskScheduler.RunTasksUntilIdle();

         // Assert
         Assert.AreEqual("Task done", sut.Status);
      }
   }
}
