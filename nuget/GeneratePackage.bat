@echo off

echo This script must be run from 'Developer Command Prompt for VS 2017' or similar developer environment.
msbuild %~dp0\..\src\Library\Library.csproj /p:Configuration=Release /v:m

REM exit if if failed
if %errorlevel% neq 0 exit /b %errorlevel%
xcopy /Y %~dp0\..\src\Library\bin\Release\net4.5\FastLinq.dll %~dp0\lib\net45
xcopy /Y %~dp0\..\src\Library\bin\Release\net4.5\FastLinq.pdb %~dp0\lib\net45

echo.
echo.
nuget pack %~dp0\Package.nuspec -OutputDirectory %~dp0