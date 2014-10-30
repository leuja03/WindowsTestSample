using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
   public class Check_Bits
   {
      public enum BitType
      {
         None = 0,
         One = 1 << 0,
         Two = 1 << 1,
         Three = 1 << 2,
         Four = 1 << 3,
         Five = 1 << 4,
         Six = 1 << 5,
         Seven = 1 << 6,
         Eight = 1 << 7,
         Nine = 1 << 8,
         Ten = 1 << 9,
      }

      public static void DoTest()
      {
         // Test bits
         int value = 3;
         TestAndValue(value);
         value = 4;
         TestAndValue(value);
         value = 10;
         TestAndValue(value);
         value = 32;
         TestAndValue(value);
         value = 59;
         TestAndValue(value);
         value = value << 2;
      }

      private static void TestAndValue(int value)
      {
         int testvalue = value & (int)BitType.One;
         testvalue = value & (int)BitType.Two;
         testvalue = value & (int)BitType.Three;
         testvalue = value & (int)BitType.Four;
         testvalue = value & (int)BitType.Five;
         testvalue = value & (int)BitType.Six;
         testvalue = value & (int)BitType.Seven;
         testvalue = value & (int)BitType.Eight;
      }
   }
}
