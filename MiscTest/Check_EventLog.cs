using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;   // eventsource
using System.Linq;
using System.Runtime.CompilerServices; // callermembername
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   /// <summary>
   /// 
   /// Check slab ~ semantic logging application block
   ///   comment: we should look into it
   /// And
   /// Check etw ~ event tracing for windows
   ///   comment: very fast logging system built into the OS
   /// 
   /// examples in microsoft:
   ///   https://msdn.microsoft.com/en-us/library/dn440729(v=pandp.60).aspx
   /// 
   /// examples in codeproject: (similar to that from MS)
   ///   http://www.codeproject.com/Articles/602077/InstrumentationpluswithplusSemanticplusLoggingplus
   /// 
   /// 
   /// 
   /// 
   /// </summary>
   public class Check_EventLog
   {
      public static void DoTest()
      {
         var res = CheckName("abc");

         // check sth
         res = CheckName();
      }

      private static string CheckName(string param = "", [CallerMemberName]string callingMember = "", [CallerFilePath]string callingFilePath = "", [CallerLineNumber]int callingLineNumber = 0)
      {
         return 
            "Parameter: " + param + "\n" +
            "Caller Member name: " + callingMember + "\n" +
            "Caller File path: " + callingFilePath + "\n" +
            "Caller Line number: " + callingLineNumber.ToString() + "\n";
      }
   }

   internal class MyEventSource : EventSource
   {
      public class Keywords
      {
         public const EventKeywords Page = (EventKeywords)1;
         public const EventKeywords DataBase = (EventKeywords)2;
         public const EventKeywords Diagnostic = (EventKeywords)4;
         public const EventKeywords Perf = (EventKeywords)8;
      }

      public class Tasks
      {
         public const EventTask Page = (EventTask)1;
         public const EventTask DBQuery = (EventTask)2;
      }

      #region Singleton
      private MyEventSource() { }
      private static MyEventSource m_log = new MyEventSource();
      public static MyEventSource Log { get { return m_log; } }
      #endregion

      [Event(100, Message = "Starting up", Keywords = Keywords.Perf)]
      internal void Start()
      {
         if (this.IsEnabled())
            this.WriteEvent(100);
      }

      [Event(200, Message="Ending")]
      internal void End()
      {
         if (this.IsEnabled())
            this.WriteEvent(200);
      }
   }
}
