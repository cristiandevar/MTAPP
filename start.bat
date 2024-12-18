@echo off
REM Mover el archivo web.config a la carpeta bin
move ".\miTiendAPP\DATA006\web\web.config" ".\miTiendAPP\DATA006\web\bin\web.config"
if %errorlevel% neq 0 (
    echo Error al mover el archivo web.config a la carpeta bin.
    pause
    exit /b %errorlevel%
)
echo El archivo web.config se movió a la carpeta bin.

REM Cambiar el directorio actual a la carpeta bin
cd /d ".\miTiendAPP\DATA006\web\bin"
if %errorlevel% neq 0 (
    echo Error al cambiar el directorio a la carpeta bin.
    pause
    exit /b %errorlevel%
)
echo Directorio cambiado a la carpeta bin.

REM Ejecutar GXConfig.exe
GXConfig.exe
if %errorlevel% neq 0 (
    echo Error al ejecutar GXConfig.exe.
    pause
    exit /b %errorlevel%
)
echo GXConfig.exe ejecutado. Configura y luego presiona Enter para continuar.
pause

REM Mover el archivo web.config de vuelta a su ubicación original
move ".\miTiendAPP\DATA006\web\bin\web.config" ".\miTiendAPP\DATA006\web\web.config"
if %errorlevel% neq 0 (
    echo Error al mover el archivo web.config de vuelta a su ubicación original.
    pause
    exit /b %errorlevel%
)
echo El archivo web.config se movió de vuelta a su ubicación original.

REM Confirmación final
echo Script completado.
pause
