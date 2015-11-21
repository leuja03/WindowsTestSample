using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Thread
{
   class AsyncTask
   {
      /// <summary>
      /// A task that pretends to do a long task...
      /// </summary>
      /// <returns></returns>
      public static async Task<string> SaySomething()
      {
         await Task.Delay(10);

         Thread_Main.CommonResource = "hello world";

         return "something";
      }
   }

   public class CallAyncClass
   {
      public async Task EnterThisClass()
      {
         await AsyncTask.SaySomething();

         await SaySomethingElse();

         DoOthers();
      }

      public async Task<string> SaySomethingElse()
      {
         await Task.Delay(100);

         Thread_Main.CommonResource = "In <SaySomethingElse()>, doing sth...";

         return "something else";
      }

      /// <summary>
      /// Do something after await...
      /// </summary>
      private void DoOthers()
      {
         int abc = 10;
         abc += 100;
         Thread_Main.CommonResource += abc.ToString();
      }
   }

}
