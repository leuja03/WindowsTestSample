// This is the main DLL file.

#include "stdafx.h"

#include "VC_CLR_Lib.h"


using namespace VC_CLR_Lib;


int g_Function1(RefClass1 data, int data2)
{
   return data.TestFunc(data2);
}

bool g_Function2(StrClass1 data, double data2)
{
   return data.TestFunc(data2);
}


void RefClass1::DoTest()
{
   RefClass1^ testObject = gcnew RefClass1();
   int result = testObject->TestFunc(1000);

   //RefClass1^ testObj2 = gcnew RefClass1(); 
   //g_Function1(*testObj2, 100);   // compile error

}


int RefClass1::TestFunc(int a)
{
   return 1;
}




void StrClass1::DoTest()
{
   StrClass1 ^a = gcnew StrClass1();
   bool result = g_Function2(*a, 2.1);
}

bool StrClass1::TestFunc(double a)
{
   return true;
}
