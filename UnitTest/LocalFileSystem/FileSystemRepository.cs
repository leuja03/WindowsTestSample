using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnitTest.LocalFileSystem
{
   /// <summary>
   /// Check this for reference:
   ///   https://visualstudiomagazine.com/articles/2011/02/16/unit-testing-in-c-sharp.aspx
   /// </summary>
   public class FileSystemRepository : IFileSystemRepository
   {
      private readonly string _Filename;

      public FileSystemRepository(string fileName)
      {
         _Filename = fileName;
      }

      public void Save(EmployeeData something)
      {
         using (var sw = new StreamWriter(_Filename, true))
         {
            SaveToStream(sw.BaseStream, something);
         }
      }

      public EmployeeData Load()
      {
         using (var sr = new StreamReader(_Filename))
         {
            return LoadFromStream(sr.BaseStream);
         }
      }


      private void SaveToStream(Stream sw, EmployeeData something)
      {
         var serializer = new XmlSerializer(typeof(EmployeeData));
         serializer.Serialize(sw, something);
      }

      private EmployeeData LoadFromStream(Stream sr)
      {
         var serializer = new XmlSerializer(typeof(EmployeeData));
         return (EmployeeData)serializer.Deserialize(sr);
      }
   }
}
