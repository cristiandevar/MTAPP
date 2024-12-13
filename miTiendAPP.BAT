cd FolderWhereStoreYouAPPDeploy\miTiendAPP\DATA006\web

start http://localhost:8082/mtaKBUpgradesforVersion1NETSQLServer/wplogin.aspx 
dotnet watch --project GxDotNetWatch.msbuild "FolderWhereStoreYouAPPDeploy\miTiendAPP\DATA006\web\bin\GxNetCoreStartup.dll"   "mtaKBUpgradesforVersion1NETSQLServer" "FolderWhereStoreYouAPPDeploy\miTiendAPP\DATA006\web" 8082 http
