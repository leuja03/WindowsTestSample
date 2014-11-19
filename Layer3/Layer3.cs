using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer3
{
    public class Layer3
    {
       public Layer3()
       {
       }

       public void DownloadTaskAsync(Layer1.Layer1.SyncTaskHandler callback)
       {
          Layer1.Layer1.SyncTaskArgs args = new Layer1.Layer1.SyncTaskArgs();
          args.Callback = callback;
          //DownloadTaskParamData parm = new DownloadTaskParamData();
          //parm.ModifiedSince = DateTime.Now;
          //args.Data = parm;
          DownloadTask(args);
       }


       protected void DownloadTask(object args)
       {
          Layer1.Layer1.SyncTaskArgs taskArgs = (Layer1.Layer1.SyncTaskArgs)args;
          Layer1.Layer1.SyncTaskEventResult result = new Layer1.Layer1.SyncTaskEventResult();


          // result must return true!!!!
          DownloadTaskInvokeCallback(taskArgs.Callback, result);

       }


       private void DownloadTaskInvokeCallback(Layer1.Layer1.SyncTaskHandler callback, object stateData)
       {
          if (callback != null)
          {
             try
             {
                callback(this, new Layer1.Layer1.SyncTaskEventArgs(stateData));
             }
             catch { }
          }
       }
    }
}
