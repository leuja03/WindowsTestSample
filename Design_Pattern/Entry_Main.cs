using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern
{
    public class Entry_Main
    {
       public static void DoTest()
       {
          Singleton_FullLazy.Instance.DoSomething();

          Singleton_MSLazyType.Instance.DoSomething();
       }
    }
}
