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

       private static void DoOthers()
       {
       }
    }

    public class CallAyncClass
    {
       public async void EnterThisClass()
       {
          await AsyncTask.SaySomething();

          DoOthers();
       }

       private void DoOthers()
       {
          int abc = 10;
          abc += 100;
          Thread_Main.CommonResource += abc.ToString();
       }
    }

 }
