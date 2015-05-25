using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check_IOC
{
   /// <summary>
   /// 
   /// https://msdn.microsoft.com/en-us/library/ff647202.aspx
   /// </summary>
   public class IOC_Main
   {
      public static void DoTest()
      {
         var container = new UnityContainer();

         container.RegisterType<ICreditCard, MasterCard>();
         //container.RegisterType<ICreditCard, MasterCard>(new InjectionProperty("ChargeCount", 5));
         //container.RegisterType<ICreditCard, MasterCard>("DefaultCard");
         //container.RegisterType<ICreditCard, Visa>("BackupCard");

         var shopper = container.Resolve<Shopper>();
         shopper.Charge();

         var shopper2 = container.Resolve<Shopper>(new ParameterOverride("creditCard", new Visa()));
         shopper2.Charge();


         container.RegisterType<ICreditCard, MasterCard>(new InjectionProperty("ChargeCount", 5));
         var shopper3 = container.Resolve<Shopper>();
         shopper3.Charge();
      }
   }
}
