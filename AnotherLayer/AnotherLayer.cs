using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherLayer
{
    public class AnotherLayer
    {
       public static void DoTest()
       {
          Layer1.Layer1.SyncTaskHandler callback = new Layer1.Layer1.SyncTaskHandler(Layer2.Layer2.SetupTaskCallback);
          Layer3.Layer3 obj = new Layer3.Layer3();
          obj.DownloadTaskAsync(callback);
       }
    }
}
