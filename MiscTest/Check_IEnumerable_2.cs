using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   //
   //http://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx
   // So, IEnumerable is more for doing collection within your class
   //
   public class Check_IEnumerable_2
   {
      public static void DoTest()
      {
         List<Item> array = new List<Item>()
         {
            new Item("John", "Smith"),
            new Item("Jim", "Johnson"),
            new Item("Sue", "Rabon"),
         };

         Items itemsList = new Items(array);
         foreach (Item p in itemsList)
            Console.WriteLine(p.First + " " + p.Second);

      }
   }

   public class Item
   {
      public Item(string fn, string ln)
      {
         First = fn;
         Second = ln;
      }

      public string First { get; set; }
      public string Second { get; set; }
   }



   public class Items : IEnumerable
   {
      private List<Item> _items;
      public Items(List<Item> pArray)
      {
         _items = new List<Item>();

         for (int i = 0; i < pArray.Count; i++)
         {
            _items[i] = pArray[i];
         }
      }

      // Implementation for the GetEnumerator method.
      IEnumerator IEnumerable.GetEnumerator()
      {
         return (IEnumerator)GetEnumerator();
      }

      public ItemsEnum GetEnumerator()
      {
         return new ItemsEnum(_items);
      }
   }

   public class ItemsEnum : IEnumerator
   {
      public List<Item> _items;

      // Enumerators are positioned before the first element 
      // until the first MoveNext() call. 
      int position = -1;

      public ItemsEnum(List<Item> list)
      {
         _items = list;
      }

      public bool MoveNext()
      {
         position++;
         return (position < _items.Count);
      }

      public void Reset()
      {
         position = -1;
      }

      object IEnumerator.Current
      {
         get
         {
            return Current;
         }
      }

      public Item Current
      {
         get
         {
            try
            {
               return _items[position];
            }
            catch (IndexOutOfRangeException)
            {
               throw new InvalidOperationException();
            }
         }
      }
   }
}
