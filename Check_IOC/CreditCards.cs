using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check_IOC
{
   public class Visa : ICreditCard
   {
      public string Charge()
      {
         return "Visa";
      }

      public int ChargeCount
      {
         get { return 0; }
      }
   }

   public class MasterCard : ICreditCard
   {
      public string Charge()
      {
         ChargeCount++;
         return "Mastercard";
      }

      public int ChargeCount
      {
         get;
         set;
      }
   }

   public class Shopper
   {
      private readonly ICreditCard _creditCard;
      private string _log;

      public Shopper(ICreditCard creditCard)
      {
         _creditCard = creditCard;
         _log = string.Empty;
      }

      public int ChargesForCurrentCard
      {
         get { return _creditCard.ChargeCount; }
      }

      public void Charge()
      {
         _log += _creditCard.Charge() + "\n";
      }
   }
}
