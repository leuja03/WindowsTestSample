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
      public void TestMethod1()
      {
         Interface_One one = new IsOne();
         var target = new BeTested(one);
         var result = target.GetInternalNum();

         var expected = -1;

         Assert.AreEqual(expected, result, "Are they equal? {0} == {1}", new object[] { expected, result });

      }

      [TestMethod]
      public void TestMehtod2()
      {
         var intOne = new Mock<Interface_One>();
         intOne.Setup(m => m.DoSth1(55555)).Returns(true);
         intOne.Setup(m => m.Num).Returns(99999);


         var target = new BeTested(intOne.Object, 77777);
         Assert.AreEqual(77777, target.GetInternalNum());

         Assert.AreEqual(99999, target.GetOneNum());

         Assert.IsFalse(target.Check_IntOne_DoSth1());


         //var realObject = new IsOne();
         //Assert.AreEqual(111, realObject.Num);

         //Assert.IsFalse( realObject.DoSth1(0));
         //Assert.IsTrue(realObject.DoSth1(111));
      }
   }
}
