@echo off
REM There are two ways to build this multi-file assembly
REM The line below picks one of those ways
Goto Way1

:Way1
csc /t:module RUT.cs
csc /out:JeffTypes.dll /t:library /addmodule:RUT.netmodule FUT.cs AssemblyVersionInfo.cs
goto Exit

:Way2
csc /t:module RUT.cs
csc /t:module FUT.cs AssemblyVersionInfo.cs
al  /out:JeffTypes.dll /t:library FUT.netmodule RUT.netmodule
goto Exit

:Exit
csc /r:JeffTypes.dll App.cs
