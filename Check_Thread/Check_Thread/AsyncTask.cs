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
      public async void EnterThisClass()
      {
         await AsyncTask.SaySomething();

         DoOthers();
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
