
@echo off 

set source=FolderWhereCreateYouKB\mtaKB
set destination=.\miTiendAPP

:start_bat

robocopy "%source%" "%destination%" /MIR /XO 


echo 'Deploy completed.' 
pause

timeout /t 1 >nul
goto start_bat