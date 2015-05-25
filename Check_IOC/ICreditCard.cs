using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check_IOC
{
   public interface ICreditCard
   {
      string Charge();
      int ChargeCount { get; }
   }
}
