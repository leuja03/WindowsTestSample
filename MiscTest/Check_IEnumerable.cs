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
   public class Check_IEnumerable
   {
      public static void DoTest()
      {
         Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

         People peopleList = new People(peopleArray);
         foreach (Person p in peopleList)
            Console.WriteLine(p.FirstName + " " + p.LastName);

      }
   }

   public class Person
   {
      public Person(string fn, string ln)
      {
         FirstName = fn;
         LastName = ln;
      }

      public string FirstName { get; set; }
      public string LastName { get; set; }
   }



   public class People : IEnumerable
   {
      private Person[] _people;
      public People(Person[] pArray)
      {
         _people = new Person[pArray.Length];

         for (int i = 0; i < pArray.Length; i++)
         {
            _people[i] = pArray[i];
         }
      }

      // Implementation for the GetEnumerator method.
      IEnumerator IEnumerable.GetEnumerator()
      {
         return (IEnumerator)GetEnumerator();
      }

      public PeopleEnum GetEnumerator()
      {
         return new PeopleEnum(_people);
      }
   }

   public class PeopleEnum : IEnumerator
   {
      public Person[] _people;

      // Enumerators are positioned before the first element 
      // until the first MoveNext() call. 
      int position = -1;

      public PeopleEnum(Person[] list)
      {
         _people = list;
      }

      public bool MoveNext()
      {
         position++;
         return (position < _people.Length);
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

      public Person Current
      {
         get
         {
            try
            {
               return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
               throw new InvalidOperationException();
            }
         }
      }
   }
}
