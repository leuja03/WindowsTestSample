using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.LocalFileSystem;
using System.IO;

namespace UnitTestProject1.LocalFileSystem
{
   [TestClass]
   public class FileSystemUnitTest
   {
      [TestMethod]
      [TestCategory("FileSystem")]
      public void TestMethod1()
      {
         var data = new EmployeeData
         {
            Id = 1,
            Name = "First Employee",
            Email = "First.Employee@email.com",
         };

         var ms = new MemoryStream();
         var repository = new FileSystemRepository("sample.xml");
         PrivateObject privateRepo = new PrivateObject(repository);
         privateRepo.Invoke("SaveToStream", new Type[] {typeof(Stream), typeof(EmployeeData) }, 
            new object[] {ms, data});

         string result = ms.ToString();

         ms.Position = 0;
         EmployeeData loaded = (EmployeeData)privateRepo.Invoke("LoadFromStream", new Type[] { typeof(Stream) },
            new object[] { ms });


         Assert.AreEqual(data.Id, loaded.Id);
         Assert.AreEqual(data.Name, loaded.Name);
         Assert.AreEqual(data.Email, loaded.Email);
      }
   }
}
