@echo off
cd /d "%~dp0"
where dotnet >nul 2>&1
if errorlevel 1 (echo dotnet SDK not found. Install .NET 8 SDK / VS desktop development with .NET. & pause & exit /b 1)
dotnet build "OliveBranchBakes.sln" -c Debug > "build-log.txt" 2>&1
type "build-log.txt"
echo.
echo Build output saved to build-log.txt
pause
