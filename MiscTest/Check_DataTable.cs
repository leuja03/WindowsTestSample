using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_DataTable
   {
      public static void DoTest()
      {
         using (DataTable testTable = CreateSampleDataTable())
         {
            testTable.Columns.Add("Id", typeof(int));
            testTable.Columns.Add("Property_1", typeof(int));
            testTable.Columns.Add("Property_2", typeof(string));
            testTable.Columns.Add("LogDate", typeof(DateTime));

            testTable.Rows.Add(1, 1000, "this is the first thing", DateTime.Now);
            testTable.Rows.Add(2, 1500, "second thing", DateTime.Now);


            foreach (DataRow dr in testTable.Rows)
            {
            }

            // this following can be helpful:
            // http://www.codeproject.com/Tips/867866/Extension-Method-for-Generic-List-Collection-to-Da

         }
      }

      private static DataTable CreateSampleDataTable()
      {
         DataTable table = new DataTable("NewTable");

         return table;
      }
   }

}
