using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;

namespace Check_EventTracing
{
    public class EventTracing_Main
    {
       // To download MS Traceevent library from nu get:
       // PM> Install-Package Microsoft.Diagnostics.Tracing.TraceEvent
       //
       // ref: https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.TraceEvent

       //http://stackoverflow.com/questions/16068051/consuming-an-etw-kernel-trace-using-c-sharp

       // http://blogs.msdn.com/b/danielvl/archive/2009/01/25/view-etw-rewrite-events.aspx

       // thisone:::
       // http://blogs.msdn.com/b/vancem/archive/2013/03/09/using-traceevent-to-mine-information-in-os-registered-etw-providers.aspx

       public static void DoTest()
       {
          CallThis();
       }

       private static void CallThis()
       {
          var sessionName = "ProcessMonitorSession";

          using (var session = new TraceEventSession(sessionName, null))
          {
             session.StopOnDispose = true;
             using (var source = new ETWTraceEventSource(sessionName, TraceEventSourceType.Session))
             {
                var registeredParser = new RegisteredTraceEventParser(source);
                registeredParser.All += delegate(TraceEvent data)
                {
                   var taskName = data.TaskName;
                   if (taskName == "ProcessStart" || taskName == "ProcessStop")
                   {
                      string exe = (string) data.PayloadByName("ImageName");
                      string exeName = Path.GetFileNameWithoutExtension(exe);

                      int processId = (int)data.PayloadByName("ProcessID");
                      if (taskName == "ProcessStart")
                      {
                         int parentProcessId = (int)data.PayloadByName("ParentProcessID");
                         // log: 
                         //string.Format("{0:HH:mm:ss.fff}: {1,-12}: {2} ID: {3} ParentID: {4}", data.TimeStamp, taskName, exeName, processId, parentProcessId);
                      }
                      else
                      {
                         int exitCode = (int)data.PayloadByName("ExitCode");
                         long cpuCycle = (long)data.PayloadByName("CPUCycleCount");
                         // log: 
                         //string.Format("{0:HH:mm:ss.fff}: {1,-12}: {2} ID: {3} EXIT: {4} CPU Cycles: {5:n0}", data.TimeStamp, taskName, exeName, processId, exitCode, cpuCycle);
                      }
                   }
                };

                //var processProviderGuid = TraceEventSession.
             }
          }
       }
    }
}
