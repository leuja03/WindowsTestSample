using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_WindowsEventLog
   {
      public static void DoTest()
      {
         CreateNewEventLogEntry();
         CreateExistingApplicationEventEntry();
      }

      // The following will create an event log, MyTestLog, in Event Viewer:
      //
      // --Evnet Viewer (Local)
      //   --Applications and Services Logs
      //     --MyTestLog
      private static void CreateNewEventLogEntry()
      {
         if (!EventLog.SourceExists("MyTestSource"))
         {
            EventLog.CreateEventSource("MyTestSource", "MyTestLog");
         }
         EventLog mylog = new EventLog();
         mylog.Source = "MyTestSource";
         mylog.WriteEntry("A new test log");
         //mylog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 0);
      }

      private static void CreateExistingApplicationEventEntry()
      {
         EventLog mylog = new EventLog();
         mylog.Source = "Application";
         mylog.WriteEntry("my test log entry 2");
      }
   }
}
