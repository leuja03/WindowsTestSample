// VC_CLR_Lib.h

#pragma once

using namespace System;

namespace VC_CLR_Lib {

	public ref class RefClass1
	{
		// TODO: Add your methods for this class here.
   public:

      // Test entry
      static void DoTest();


      // Test "Handle to Object Operator
      int TestFunc(int a);
	};

   // http://msdn.microsoft.com/en-us/library/yk97tc08.aspx
   public value struct StrClass1
   {
   public:
      static void DoTest();



      bool TestFunc(double a);
   };
}
