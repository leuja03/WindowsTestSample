using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer1
{
    public class Layer1
    {
       public class SyncTaskArgs
       {
          public SyncTaskHandler Callback { get; set; }
          public object Data { get; set; }
       }

       public class SyncTaskEventArgs
       {
          public object Data { get; set; }

          public SyncTaskEventArgs(object data)
          {
             this.Data = data;
          }
       }

       public class SyncTaskEventResult
       {
          public object Data { get; set; }
       }

       public delegate void SyncTaskHandler(object sender, SyncTaskEventArgs args);
    }
}
