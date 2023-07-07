@echo off
call SetMikanVars_x64.bat

:: Set path variables
set "SOURCE_SCRIPTS=%MIKAN_PLUGIN_PATH%\Assets\Scripts"
set "SOURCE_BIN=%MIKAN_PLUGIN_PATH%\Assets\Plugins"

set "TARGET_SCRIPTS=%~dp0MikanXR"
set "TARGET_BIN=%~dp0"

:: delete old script files
del /s /q "%TARGET_SCRIPTS%\*.cs"

:: Copy over the C# files
xcopy /e /y /r "%SOURCE_SCRIPTS%\*.cs" "%TARGET_SCRIPTS%" || goto failure

:: Copy over the client DLLs
xcopy /y /r "%SOURCE_BIN%\*.dll" "%TARGET_BIN%" || goto failure

echo "Successfully updated MikanXR Unity Plugin from: %MIKAN_PLUGIN_PATH%"
pause
EXIT /B 0

:failure
echo "Failed to copy files from MikanXR Unity Plugin"
pause
EXIT /B 1