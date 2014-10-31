using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Create_DummyFiles
   {
      public static void DoTest()
      {
         string filename = "test";   // args[0]
         string filesize = "10000";   // args[1]
         m_fileName = filename;
         m_fileSize = filesize;

         if (CreateDummyFile(filename, filesize))
         {
            string msg = string.Format("File {0} with size {1} created at {2}.", m_fileName, m_fileSize, "");
            Console.WriteLine(msg);
         }
         else
            Console.WriteLine();
      }


      private static string m_fileName = string.Empty;
      private static string m_fileSize = string.Empty;
      private static string m_exception = string.Empty;

      /// <summary>
      /// reference:
      /// http://stackoverflow.com/questions/1881050/creating-a-huge-dummy-file-in-a-matter-of-seconds-in-c-sharp
      /// </summary>
      /// <returns></returns>
      private static bool CreateDummyFile(string fileName, string fileSize)
      {
         bool error = false;
         try
         {
            FileStream fs = new FileStream(@"c:\abc\" + fileName, FileMode.CreateNew);
            //fs.Seek(2048L * 1024 * 1024, SeekOrigin.Begin);
            fs.Seek(int.Parse(fileSize), SeekOrigin.Begin);
            fs.WriteByte(0);
            fs.Close();
         }
         catch (Exception e)
         {
            error = true;
            m_exception = e.Message;
         }
         finally
         {
         }

         return error;
      }
   }
}
