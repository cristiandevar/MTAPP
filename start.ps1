
$ErrorActionPreference = "Stop" 
try {

Move-Item -Path ".\miTiendAPP\DATA006\web\web.config" -Destination ".\miTiendAPP\DATA006\web\bin\web.config"

Set-Location ".\miTiendAPP\DATA006\web\bin"

.\GXConfig.exe

Read-Host -Prompt "Presiona Enter cuando hayas terminado con GXConfig.exe"

Move-Item -Path ".\miTiendAPP\DATA006\web\bin\web.config" -Destination ".\miTiendAPP\DATA006\web\web.config"

Write-Host "Archivo web.config ha sido movido de vuelta a su ubicación original."

} catch { 
    Write-Host "Ocurrió un error: $_" -ForegroundColor Red Read-Host -Prompt "Presiona Enter para continuar" 
}
Write-Host "Script completado." -ForegroundColor Cyan

