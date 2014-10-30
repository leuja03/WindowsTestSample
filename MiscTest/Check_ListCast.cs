using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_ListCast
   {
      public static void DoTest()
      {
         List<Parent> parent = new List<Parent>()
         {
            new Parent() { TheInt = 1, TheList = new List<int>() { 1, 1, 1 },},
            new Parent() { TheInt = 2, TheList = new List<int>() { 2, 2, 2 },},
         };

         List<Child> child = new List<Child>()
         {
            new Child() { TheInt = 1, TheList = new List<int>() { 555, 555, 555 }, TheString = "AAA", },
            new Child() { TheInt = 2, TheList = new List<int>() { 666, 666, 666 }, TheString = "BBB", },
         };

         List<Parent> test = parent;
         //test = (List<Parent>)child;
         // http://stackoverflow.com/questions/1777800/in-c-is-it-possible-to-cast-a-listchild-to-listparent
         test = child.Cast<Parent>().ToList();
      }
   }

   class Parent
   {
      public Parent()
      {
         m_list = new List<int>();
         m_int = -1;
      }

      protected List<int> m_list;
      protected int m_int;

      public virtual List<int> TheList
      {
         get { return m_list; }
         set { m_list = value; }
      }

      public virtual int TheInt
      {
         get { return m_int; }
         set { m_int = value; }
      }
   }

   class Child : Parent
   {
      public Child()
      {
         m_string = "child";
      }

      private string m_string;

      public string TheString
      {
         get { return m_string; }
         set { m_string = value; }
      }
   }
}
