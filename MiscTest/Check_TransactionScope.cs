using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MiscTest
{
   public class Check_TransactionScope
   {
      /// <summary>
      /// Reference:
      ///   http://www.codeguru.com/csharp/.net/net_data/sortinganditerating/article.php/c10993/SystemTransactions-Implement-Your-Own-Resource-Manager.htm
      ///   
      ///   https://msdn.microsoft.com/en-us/library/ee818746(v=vs.110).aspx
      ///   
      /// </summary>
      public static void DoTest()
      {
         VolatileRM vrm = null;
         using (TransactionScope txSc = new TransactionScope())
         {
            vrm = new VolatileRM();
            vrm.SetMemberValue(3);

            txSc.Complete();
         }



         VolatileRM_MyExample vrm_rb = null;
         // Test rollback
         try
         {
            vrm_rb = new VolatileRM_MyExample();
            vrm_rb.MemberValue = 888;
            vrm_rb.MemberValue = 777;
            vrm_rb.MemberValue = 555;

            using (TransactionScope txSc = new TransactionScope())
            {
               vrm_rb.MemberValue = 222;

               txSc.Complete();
            }

            using (TransactionScope txSc = new TransactionScope())
            {
               //vrm_rb = new VolatileRM_Rollback();
               vrm_rb.MemberValue = 1;

               ThrowException();
               
               txSc.Complete();
            }
         }
         catch
         {
         }


         Logger.TheInstance.PurgeSingleton();
      }

      private static void ThrowException()
      {
         throw new Exception("throw exception in transactionscope");
      }
   }

   internal class Logger
   {
      private string m_log = string.Empty;

      #region Singleton
      private static Logger m_instance = null;

      protected Logger()
      {
      }

      public static Logger TheInstance
      {
         get
         {
            if (m_instance == null)
               m_instance = new Logger();
            return m_instance;
         }
      }
      #endregion

      public void PurgeSingleton()
      {
         m_instance = null;
      }

      public void WriteToLog(string sth)
      {
         if (sth == null)
            return;
         m_log += "\n" + sth;
      }
   }

   internal class VolatileRM : IEnlistmentNotification
   {
      private const int DEFAULT = -999;
      private int memberValue = DEFAULT;
      private int oldMemberValue = DEFAULT;
 
      public int MemberValue
      {
         get { return memberValue; }
      }
 
      public void SetMemberValue(int newMemberValue)
      {
         Transaction currentTx = Transaction.Current;
         if (currentTx != null)
         {
            Logger.TheInstance.WriteToLog("VolatileRM: SetMemberValue - EnlistVolatile");
            currentTx.EnlistVolatile(this, EnlistmentOptions.None);
         }

         oldMemberValue = memberValue;
         memberValue = newMemberValue;
      }


      #region interface for  IEnlistmentNotification
      public void Commit(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Commit");
         // Clear out oldMemberValue
         oldMemberValue = 0;
      }
 
      public void InDoubt(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: InDoubt");
      }
 
      public void Prepare(PreparingEnlistment preparingEnlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Prepare");
         preparingEnlistment.Prepared();
      }

      public void Rollback(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Rollback");
         // Restore previous state
         memberValue = oldMemberValue;
         oldMemberValue = 0;
      }
      #endregion
   }

   internal abstract class AbstractTransactionScope : IEnlistmentNotification
   {
      #region interface for  IEnlistmentNotification
      public void Commit(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Commit");

         Transaction currentTx = Transaction.Current;
         if (currentTx != null)
            currentTx.Rollback(new Exception("what ever happend"));

         // Clear out oldMemberValue
         DoCommit();

         enlistment.Done();
      }

      public void InDoubt(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: InDoubt");
         DoInDoubt();

         enlistment.Done();
      }

      public void Prepare(PreparingEnlistment preparingEnlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Prepare - Force to rollback");
         DoPrepare();

         preparingEnlistment.Prepared();
      }

      public void Rollback(Enlistment enlistment)
      {
         Logger.TheInstance.WriteToLog("VolatileRM: Rollback");
         // Restore previous state
         DoRollback();

         enlistment.Done();
      }
      #endregion

      protected abstract void DoCommit();
      protected abstract void DoInDoubt();
      protected abstract void DoPrepare();
      protected abstract void DoRollback();
   }

   internal class VolatileRM_MyExample : AbstractTransactionScope
   {
      private const int DEFAULT = -999;
      private int memberValue = DEFAULT;
      private int oldMemberValue = DEFAULT;
      
      public int MemberValue
      {
         get { return memberValue; }
         set
         {
            Transaction currentTx = Transaction.Current;
            if (currentTx != null)
            {
               Logger.TheInstance.WriteToLog("VolatileRM: SetMemberValue - EnlistVolatile");
               currentTx.EnlistVolatile(this, EnlistmentOptions.None);
            }

            oldMemberValue = memberValue;
            memberValue = value;
         }
      }

      protected override void DoCommit()
      {
      }

      protected override void DoInDoubt()
      {
      }

      protected override void DoPrepare()
      {
      }

      protected override void DoRollback()
      {
         memberValue = oldMemberValue;
      }
   }

}
