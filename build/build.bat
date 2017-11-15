@echo off
set currentDir=%CD%
path %PATH%;C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\;C:\Program Files (x86)\MSBuild\14.0\Bin\;
cd %currentDir%\..\src\aliyun-net-sdk-core
msbuild /t:pack /p:Configuration=Release

cd %currentDir%\..\src\aliyun-net-sdk-sms
msbuild /t:pack /p:Configuration=Release

pause
