using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectToBeTested;
using Moq;


namespace UnitTestProject1
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void Test_BeTested_Mock_InterfaceOne()
      {
         // Set up mock for interface_one
         var intOne = new Mock<Interface_One>();
         intOne.Setup(m => m.DoSth1(55555)).Returns(true);
         intOne.Setup(m => m.Num).Returns(99999);
         
         var target = new BeTested(intOne.Object, 77777);
         Assert.AreEqual(77777, target.GetInternalNum());

         Assert.AreEqual(99999, target.GetOneNum());

         Assert.IsFalse(target.Check_IntOne_DoSth1());
      }

      #region Test solid constructors, BeTested, IsOne
      [TestMethod]
      public void Test_BeTested_Constructor()
      {
         Interface_One one = new IsOne();
         // Constructor one
         var target = new BeTested(one);
         var result = target.GetInternalNum();
         var expected = -1;
         Assert.AreEqual(expected, result, "Are they equal? {0} == {1}", new object[] { expected, result });
      }

      [TestMethod]
      public void Test_IsOne_Constructor()
      {
         var realObject = new IsOne();
         Assert.AreEqual(111, realObject.Num);
         Assert.IsFalse(realObject.DoSth1(0));
         Assert.IsTrue(realObject.DoSth1(111));

         var realObject2 = new IsOne(222);
         Assert.AreEqual(222, realObject2.Num);
         Assert.IsFalse(realObject2.DoSth1(0));
         Assert.IsTrue(realObject2.DoSth1(222));
         realObject2.Num = 999;
         Assert.AreEqual(999, realObject2.Num);
      }
      #endregion
   }
}
