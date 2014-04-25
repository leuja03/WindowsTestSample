using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToBeTested
{
   public class BeTested 
   {
      private int m_internalInt = 0;
      private Interface_One m_interfaceOne;

      public BeTested(Interface_One one) : this(one, -1)
      {
      }

      public BeTested(Interface_One one, int init)
      {
         m_interfaceOne = one;
         m_internalInt = init;
      }

      public int GetInternalNum()
      {
         return m_internalInt;
      }

      public int GetOneNum()
      {
         return m_interfaceOne.Num;
      }

      public bool Check_IntOne_DoSth1()
      {
         return m_interfaceOne.DoSth1(m_interfaceOne.Num);
      }
   }

   public class IsOne : Interface_One
   {
      public int m_num = 111;

      public bool DoSth1(int check)
      {
         return check == m_num;
      }

      public int Num
      {
         get { return m_num; }
         set { m_num = value; }
      }
   }
}
