using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            vrm.MemberValue = 3;

            txSc.Complete();
         }



         VolatileRM_MyExample vrm_rb = null;
         try
         {
            vrm_rb = new VolatileRM_MyExample();
            vrm_rb.MemberValue = 888;
            vrm_rb.MemberValue = 777;
            vrm_rb.MemberValue = 555;

            // Test nested transactionscope
            using (TransactionScope txSc = new TransactionScope())
            {
               vrm_rb.MemberValue = 222;

               using (TransactionScope txSc2 = new TransactionScope())
               {
                  vrm.MemberValue = 13579;
                  txSc2.Complete();
               }

               txSc.Complete();
            }

            // Test rollback
            using (TransactionScope txSc = new TransactionScope())
            {
               vrm_rb.MemberValue = 1;

               using (TransactionScope txSc2 = new TransactionScope())
               {
                  vrm.MemberValue = 2468;

                  txSc2.Complete();
               }

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

      public void WriteToLog(string sth, [CallerMemberName]string callingMember = "")
      {
         if (sth == null)
            return;
         m_log += "\n" + "[" + callingMember + "]:" + sth;
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
         Logger.TheInstance.WriteToLog("VolatileRM: Prepare");
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

      protected bool InTransactionScope
      {
         get
         {
            Transaction currentTx = Transaction.Current;
            // enlist itself
            if (currentTx != null)
               currentTx.EnlistVolatile(this, EnlistmentOptions.None);

            return (currentTx != null);
         }
      }
   }

   internal class VolatileRM_MyExample : AbstractTransactionScope
   {
      private const int DEFAULT = -999;
      private int memberValue = DEFAULT;
      private int oldMemberValue = DEFAULT;
      private int newMemberValue = DEFAULT;
      
      public int MemberValue
      {
         get 
         {
            if (InTransactionScope)
               return newMemberValue;
            else
               return memberValue; 
         }
         set
         {
            newMemberValue = value;

            if (InTransactionScope)
            {
            }
            else
            {
               DoPrepare();
               DoCommit();
            }
         }
      }

      protected override void DoCommit()
      {
         memberValue = newMemberValue;
      }

      protected override void DoInDoubt()
      {
         DoRollback();//????
      }

      protected override void DoPrepare()
      {
         oldMemberValue = memberValue;
      }

      protected override void DoRollback()
      {
      }
   }

}
