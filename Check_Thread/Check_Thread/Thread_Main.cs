using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;

namespace Check_Thread
{
    public class Thread_Main
    {
       public static string CommonResource = string.Empty;

       public static void DoTest()
       {
          SystemUnderTest sut = new SystemUnderTest(TaskScheduler.FromCurrentSynchronizationContext());
          sut.DoAsync();

          new CallAyncClass().EnterThisClass();

          DoOthers();
       }

       /// <summary>
       /// some empty functions... just to check if this is called after await
       /// </summary>
       private static void DoOthers()
       {
       }
    }
 }
