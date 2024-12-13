cd 'C:\Universidad\Seminario Tecnico Profesional\KB\mtaKB\DATA006\web'
start http://localhost:8082/mtaKBUpgradesforVersion1NETSQLServer/wplogin.aspx 
dotnet watch --project GxDotNetWatch.msbuild "C:\Universidad\Seminario Tecnico Profesional\KB\mtaKB\Data006\web\bin\GxNetCoreStartup.dll"   "mtaKBUpgradesforVersion1NETSQLServer" "C:\Universidad\Seminario Tecnico Profesional\KB\mtaKB\Data006\web" 8082 http
