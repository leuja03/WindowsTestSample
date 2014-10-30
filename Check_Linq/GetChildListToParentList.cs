using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Linq
{
   public class GetChildListToParentList
   {
      public static void DoTest()
      {
         // Create a list with parents and children
         List<GrandParent> gList = new List<GrandParent>()
         {
            new Parent() { ThisDouble = 1.1, ThisInt = 1},
            new Parent() { ThisDouble = 2.2, ThisInt = 2},
            new ChildA() { ThisDouble = 100.1, ThisInt = 101, ThisString = "first child A" },
            new ChildB() { ThisDouble = 200.2, ThisInt = 202},
         };


         // Test if can return child lists to parent list holders
         var query3 = new Parent().GetSpecificList(gList);
         var query4 = new Parent().GetSpecificList_TraditionalWay(gList);
         query3 = new ChildA().GetSpecificList(gList);
         query4 = new ChildA().GetSpecificList_TraditionalWay(gList);
         query3 = new ChildB().GetSpecificList(gList);
         query4 = new ChildB().GetSpecificList_TraditionalWay(gList);
      }



      abstract class GrandParent
      {
         public double ThisDouble { get; set; }

         public abstract List<GrandParent> GetSpecificList(List<GrandParent> originalList);

         protected abstract bool CheckRuntimeType(GrandParent item);
         public List<GrandParent> GetSpecificList_TraditionalWay(List<GrandParent> originalList)
         {
            if (null == originalList) return null;

            List<GrandParent> resultList = new List<GrandParent>();
            foreach (GrandParent item in originalList)
            {
               if (CheckRuntimeType(item))
                  resultList.Add(item);
            }
            return resultList;
         }
      }

      class Parent : GrandParent
      {
         public int ThisInt { get; set; }

         public override List<GrandParent> GetSpecificList(List<GrandParent> originalList)
         {
            if (null == originalList) return null;
            return originalList.OfType<Parent>().Where(item => item.GetType() == typeof(Parent)).Cast<GrandParent>().ToList();
         }

         protected override bool CheckRuntimeType(GrandParent item)
         {
            if (item == null) return false;
            return item.GetType() == typeof(Parent);
         }
      }

      class ChildA : Parent
      {
         public string ThisString { get; set; }

         public override List<GrandParent> GetSpecificList(List<GrandParent> originalList)
         {
            if (null == originalList) return null;
            return originalList.OfType<ChildA>().Where(item => item.GetType() == typeof(ChildA)).Cast<GrandParent>().ToList();
         }

         protected override bool CheckRuntimeType(GrandParent item)
         {
            if (item == null) return false;
            return item.GetType() == typeof(ChildA);
         }
      }

      class ChildB : Parent
      {
         public override List<GrandParent> GetSpecificList(List<GrandParent> originalList)
         {
            if (null == originalList) return null;
            return originalList.OfType<ChildB>().Where(item => item.GetType() == typeof(ChildB)).Cast<GrandParent>().ToList();
         }

         protected override bool CheckRuntimeType(GrandParent item)
         {
            if (item == null) return false;
            return item.GetType() == typeof(ChildB);
         }
      }
   }
}
