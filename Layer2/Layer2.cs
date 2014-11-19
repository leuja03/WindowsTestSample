using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer2
{
    public class Layer2
    {
       public static void SetupTaskCallback(object sender, Layer1.Layer1.SyncTaskEventArgs args)
       {
          //   this.Invoke(new UpdateDownloadStatusLabelHandler(UpdateDownloadStatusLabel), SimplyLanguage.Instance.GetString("NET_SageOne", "SYNC_SELCOMP_CONNECT"));
          //   this.Invoke(new UpdatePictureBoxHandler(UpdatePictureBox), m_connectPictureBox, SageOneSyncUtil.StatusImage.PROGRESS);
          //   this.Invoke(new SageOneLoginHandler(SageOneLogin), args.Data);
          Layer1.Layer1.SyncTaskEventResult result = args.Data as Layer1.Layer1.SyncTaskEventResult;
          result.Data = true;
       }
    }
}
