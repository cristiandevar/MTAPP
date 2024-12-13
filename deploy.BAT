
@echo off 

set source=FolderWhereCreateYouKB\mtaKB\
set destination=FolderWhereStoreYouAPPDeploy\miTiendAPP

:start_bat

robocopy "%source%" "%destination%" /MIR /XO 


echo 'Copy completed.' 
pause

timeout /t 1 >nul
goto start_bat