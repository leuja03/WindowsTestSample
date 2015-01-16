using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Linq
{
   public class Order
   {
      public static void DoTest()
      {
         TestSort1();
      }

      static void TestSort1()
      {
         List<SmallClass> list = new List<SmallClass>()
         {
            new SmallClass(100, 1000, 9),
            new SmallClass(105, 900, 99),
            new SmallClass(90, 1100, 999),
            new SmallClass(200, 1200, 9999),
            new SmallClass(90, 1050, 99999),
         };

         foreach (SmallClass item in list)
         {
         }

         // sort
         IEnumerable<SmallClass> sorted = list.OrderBy(x => x.Int1).ThenBy(y => y.Int2);

         foreach (SmallClass item in sorted)
         {
         }
      }

      private class SmallClass
      {
         public SmallClass(int int1, int int2, int value)
         {
            Int1 = int1;
            Int2 = int2;
            Value = value;
         }

         public int Int1
         {
            get;
            set;
         }

         public int Int2
         {
            get;
            set;
         }

         public int Value
         {
            get;
            set;
         }
      }
   }

}
