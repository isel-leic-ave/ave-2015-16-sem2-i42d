#include <stdio.h>        // For printf
#using <mscorlib.dll>     // For managed types defined in this assembly
using namespace System;   // Easily access System namespace types

// Implement a normal C/C++ main function
void main() {

   // Call the C runtime library's printf function.
   printf("Displayed by printf.\r\n");

   // Call the FCL’s System.Console's WriteLine method.
   Console::WriteLine("Displayed by Console::WriteLine.");
}
