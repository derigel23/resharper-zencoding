@echo off
call "%VS90COMNTOOLS%vsvars32.bat"

:Build
cls
msbuild Build\Build.proj

rem Loop the build script.
set CHOICE=nothing
echo (Q)uit, (Enter) runs the build again
set /P CHOICE= 
if /i "%CHOICE%"=="Q" goto :Quit

GOTO Build

:Quit
exit /b %errorlevel%