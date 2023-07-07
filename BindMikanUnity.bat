@echo off
setlocal

::Select the path to the root Boost folder
if DEFINED MIKAN_PLUGIN_PATH (goto setup_copy_script)
set "psCommand="(new-object -COM 'Shell.Application')^
.BrowseForFolder(0,'Please select the root folder for MikanUnity Plugin github build (ex: C:\MikanXR_Unity).',0,0).self.path""
for /f "usebackq delims=" %%I in (`powershell %psCommand%`) do set "MIKAN_PLUGIN_PATH=%%I"
if NOT DEFINED MIKAN_PLUGIN_PATH (goto failure)

:setup_copy_script

:: Write out the paths to a batch file
del SetMikanVars_x64.bat
echo @echo off >> SetMikanVars_x64.bat
echo set "MIKAN_PLUGIN_PATH=%MIKAN_PLUGIN_PATH%" >> SetMikanVars_x64.bat

:: Copy latest Mikan Plugin
call FetchMikanUnity.bat || goto failure
EXIT /B 0

:failure
pause
EXIT /B 1