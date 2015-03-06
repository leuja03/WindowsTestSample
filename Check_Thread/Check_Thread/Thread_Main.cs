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
       public static void DoTest()
       {
          SystemUnderTest sut = new SystemUnderTest(TaskScheduler.FromCurrentSynchronizationContext());
          sut.DoAsync();
       }
    }

 }
